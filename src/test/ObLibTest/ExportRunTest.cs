using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


using ObLib;
using ObLib.Domain;
using ObLib.Export;
using ObLibTest.Fixtures;

namespace ObLibTest
{
    public class ExportRunTest
    {
        private ExportRun exportRun = null;

        [SetUp]
        public void SetupContext()
        {
            Fixtures.Fixtures.setup();

            exportRun = new ExportRun();
        }

        [TearDown]
        public void TearDownContext()
        {
        }

        [Test]
        public void testBehaviorAndTestSetup()
        {
            Assert.NotNull(Fixtures.Fixtures.swimming);
            Assert.NotNull(Fixtures.Fixtures.climbing);
            Assert.NotNull(Fixtures.Fixtures.floating);

            BehavioralTest fstTest = Fixtures.Fixtures.fstTest;
            Trial trial = fstTest.Sessions[0].Trials[0];
            Subject subject = Researcher.Current.ActiveProject.Subjects[1];

            Assert.AreEqual(fstTest.BehavioralTestType, BehavioralTestType.Fst);
            Assert.AreEqual("T1", trial.Name);
            Assert.AreEqual("2", subject.Code);
            Assert.AreEqual(2, trial.Runs.Count);
            Assert.AreEqual(0, trial.CompleteRunCount);
        }

        [Test]
        public void testFstHeader()
        {
            Trial trial = Fixtures.Fixtures.fstTrial;
            Run run = Fixtures.Fixtures.createSampleRun(trial);

            Assert.AreEqual(15, run.Trial.Duration);
            Assert.AreEqual(9, run.RunEvents.Count);
            Assert.AreEqual(2.1, run.RunEvents[1].TimeTrackedInSeconds);

            exportRun.exportRun(run);
            Assert.AreEqual(23, exportRun.fstHeaders(run.Trial).Count);
            run.RunEvents.Clear();
        }

        [Test]
        public void testTimeBins()
        {
            Trial trial = Fixtures.Fixtures.fstTrial;
            Run run = Fixtures.Fixtures.createSampleRun(trial);

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
            Assert.AreEqual(3800, timeBins[0].stateBehaviorTotalDuration[Fixtures.Fixtures.swimming]);

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
    }
}