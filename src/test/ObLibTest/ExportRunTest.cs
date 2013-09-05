using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using ObLib;
using ObLib.Domain;

namespace ObLibTest
{
    public class ExportRunTest
    {
        [SetUp]
        public void SetupContext()
        {
        }

        [TearDown]
        public void TearDownContext()
        {
        }

        [Test]
        public void testFstHeader()
        {
            Researcher researcher = Researcher.Find("admin");
            Researcher.Current = researcher;
            BehavioralTest fstTest = researcher.ActiveProject.BehavioralTests[0];
            Trial trial = fstTest.Sessions[0].Trials[0];

            List<Behavior> behaviors = fstTest.GetBehaviors();
            Behavior swimming = null;
            Behavior climbing = null;
            Behavior floating = null;

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
            Assert.NotNull(swimming);
            Assert.NotNull(climbing);
            Assert.NotNull(floating);

            Subject subject = researcher.ActiveProject.Subjects[1];
            Assert.AreEqual(fstTest.BehavioralTestType, BehavioralTestType.Fst);
            Assert.AreEqual("T1", trial.Name);
            Assert.AreEqual("2", subject.Code);
            Assert.AreEqual(5, trial.Runs.Count);
            Assert.AreEqual(2, trial.CompleteRunCount);

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

            Assert.AreEqual(15, run.Trial.Duration);

            Assert.AreEqual(2, run.Id);
            Assert.AreEqual(9, run.RunEvents.Count);
            Assert.AreEqual(2.1, run.RunEvents[1].TimeTrackedInSeconds);

            ExportRun exportRun = new ExportRun();

            List<TimeBin> timeBins = TimeBin.runTimeBins(run);
            Assert.AreEqual(3, timeBins.Count);
            Assert.AreEqual(5000, timeBins[1].start);
            Assert.AreEqual(10000, timeBins[1].end);

            exportRun.exportRun(run);
            Assert.AreEqual(3, exportRun.timeBins.Count);
            Assert.AreEqual(3800, exportRun.timeBins[0].stateBehaviorTotalDuration[swimming]);
            Assert.AreEqual(23, exportRun.fstHeaders(run.Trial.Session.BehavioralTest).Count);
            run.RunEvents.Clear();
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