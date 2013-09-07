using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using ObLib;
using ObLib.Domain;
using ObLib.Export;

namespace ObLibTest
{
    public class ExportRunTest
    {
        private Behavior swimming = null;
        private Behavior climbing = null;
        private Behavior floating = null;
        private ExportRun exportRun = null;

        [SetUp]
        public void SetupContext()
        {
            Researcher researcher = Researcher.Find("admin");
            Researcher.Current = researcher;
            BehavioralTest fstTest = researcher.ActiveProject.BehavioralTests[0];
            exportRun = new ExportRun();

            List<Behavior> behaviors = fstTest.GetBehaviors();

            foreach (Behavior behavior in behaviors)
            {
                if ("Swimming" == behavior.Name)
                {
                    swimming = behavior;
                }
                if ("Climbing" == behavior.Name)
                {
                    climbing = behavior;
                }
                if ("Floating" == behavior.Name)
                {
                    floating = behavior;
                }
            }
        }

        [TearDown]
        public void TearDownContext()
        {
        }

        [Test]
        public void testFstHeader()
        {
            Researcher researcher = Researcher.Current;
            BehavioralTest fstTest = researcher.ActiveProject.BehavioralTests[0];
            Trial trial = fstTest.Sessions[0].Trials[0];

            Assert.NotNull(swimming);
            Assert.NotNull(climbing);
            Assert.NotNull(floating);

            Subject subject = researcher.ActiveProject.Subjects[1];
            Assert.AreEqual(fstTest.BehavioralTestType, BehavioralTestType.Fst);
            Assert.AreEqual("T1", trial.Name);
            Assert.AreEqual("2", subject.Code);
            Assert.AreEqual(5, trial.Runs.Count);
            Assert.AreEqual(2, trial.CompleteRunCount);

            Run run = createSampleRun(trial);

            Assert.AreEqual(15, run.Trial.Duration);

            Assert.AreEqual(2, run.Id);
            Assert.AreEqual(9, run.RunEvents.Count);
            Assert.AreEqual(2.1, run.RunEvents[1].TimeTrackedInSeconds);

            exportRun.exportRun(run);
            Assert.AreEqual(23, exportRun.fstHeaders(run.Trial).Count);
            run.RunEvents.Clear();
        }

        [Test]
        public void testTimeBins()
        {
            Researcher researcher = Researcher.Current;
            BehavioralTest fstTest = researcher.ActiveProject.BehavioralTests[0];
            Trial trial = fstTest.Sessions[0].Trials[0];
            Run run = createSampleRun(trial);

            List<RunEvent> sortedRunEvents = new List<RunEvent>(run.RunEvents);
            sortedRunEvents.Sort(new Comparison<RunEvent>((re1, re2) => (int)(re1.TimeTracked - re2.TimeTracked)));

            List<RunEvent> sortedStateRunEvents = sortedRunEvents.FindAll(new Predicate<RunEvent>(r => r.Behavior.Type == Behavior.BehaviorType.State));

            ExportTimeBin exportTimeBin = new ExportTimeBin(run, 5);
            List<TimeBin> timeBins = exportTimeBin.calculateTimeBins(sortedStateRunEvents);

            // initialization
            Assert.AreEqual(3, timeBins.Count);
            Assert.AreEqual(5000, timeBins[1].start);
            Assert.AreEqual(10000, timeBins[1].end);
            
            // calculation
            Assert.AreEqual(3800, timeBins[0].stateBehaviorTotalDuration[swimming]);

            // export headers
            List<string> headers = exportTimeBin.headers();
            Assert.AreEqual(12, headers.Count);
            Assert.AreEqual("Climbing 0-5", headers[0]);
            Assert.AreEqual("Climbing 5-10", headers[1]);
            Assert.AreEqual("Swimming 0-5", headers[3]);
            Assert.AreEqual("Diving 10-15", headers[11]);

            // export data
            List<string> data = exportTimeBin.data();
            Assert.AreEqual(12, data.Count);
            Assert.AreEqual("1,200", data[0]);
            Assert.AreEqual("0,000", data[1]);
            Assert.AreEqual("3,800", data[3]);
            Assert.AreEqual("0,000", data[11]);

            //exportRun = new ExportRun(new ExportSettings(5));
            //exportRun.exportRun(run);
            run.RunEvents.Clear();
        }

        private Run createSampleRun(Trial trial)
        {
            Run run = trial.Runs[1];

            run.RunEvents.Clear();

            addRunEvent(run, swimming, 0);
            addRunEvent(run, climbing, 2100);
            addRunEvent(run, swimming, 3300);
            addRunEvent(run, floating, 5200);
            addRunEvent(run, swimming, 7500);
            addRunEvent(run, floating, 11300);
            addRunEvent(run, swimming, 12500);
            addRunEvent(run, floating, 13300);
            addRunEvent(run, climbing, 14700);

            run.TmRun = DateTime.Now;
            run.Save();
            run.Trial.Duration = 15;
            run.Trial.Save();
            return run;
        }

        void addRunEvent(Run run, Behavior behavior, long timeTracked)
        {
            RunEvent runEvent = new RunEvent();
            runEvent.TimeTracked = timeTracked;
            runEvent.Behavior = behavior;
            run.AddRunEvent(runEvent);
        }
    }
}