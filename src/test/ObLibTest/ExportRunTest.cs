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
    [TestFixture]
    public class ExportRunTest
    {
        [TestFixtureSetUp]
        public void SetupTestClass()
        {
            Fixtures.Fixtures.setup();
        }

        [SetUp]
        public void SetupContext()
        {
        }

        [TearDown]
        public void TearDownContext()
        {
        }

        [Test]
        public void testBehaviorAndBehavioralTestSetup()
        {
            Assert.NotNull(Fixtures.Fixtures.FstSwimming);
            Assert.NotNull(Fixtures.Fixtures.FstClimbing);
            Assert.NotNull(Fixtures.Fixtures.FstFloating);
            Assert.NotNull(Fixtures.Fixtures.FstDiving);
            Assert.NotNull(Fixtures.Fixtures.FstHeadSwinging);
            Assert.NotNull(Fixtures.Fixtures.OrObjectA);
            Assert.NotNull(Fixtures.Fixtures.OrObjectB);
            Assert.NotNull(Fixtures.Fixtures.OrGeneralArea);

            BehavioralTest fstTest = Fixtures.Fixtures.fstLightTest;
            Trial trial = fstTest.Sessions[0].Trials[0];
            Subject subject = Researcher.Current.ActiveProject.Subjects[1];

            Assert.AreEqual(fstTest.BehavioralTestType, BehavioralTestType.Fst);
            Assert.AreEqual("T1", trial.Name);
            Assert.AreEqual("2", subject.Code);
            Assert.AreEqual(2, trial.Runs.Count);
            Assert.AreEqual(0, trial.CompleteRunCount);
        }

        [Test]
        public void testObjectRecognitionHeader()
        {
            Trial trial = Fixtures.Fixtures.orTrial;
            Run run = Fixtures.Fixtures.createObjectRecognitionRun(trial);
            ExportRun exportRun = ExportRun.Create(run, new ExportSettings(trial));

            Assert.AreEqual(100, run.Trial.Duration);
            Assert.AreEqual(13, run.RunEvents.Count);
            Assert.AreEqual(1.1, run.RunEvents[1].TimeTrackedInSeconds);

            List<string> headers = exportRun.Headers();
            List<string> expectedSubjectHeaders = new List<string>(){
                "Project", "SubjectID", "SubjectGroup", "Strain", "Sex",
                "TrialName", "TrialDuration", "DateRun", "TimeRun"
            };

            List<string> expectedDurationHeaders = new List<string>(){
                "Object A Duration", "Object B Duration", "General Area Duration"
            };

            // standard, duration, frequency, latency
            Assert.AreEqual(10 + 3 + 3 + 3, headers.Count, "Items on Object Recognition header output");
            Assert.AreEqual(expectedSubjectHeaders, headers.GetRange(0, 9));
            Assert.AreEqual(expectedDurationHeaders, headers.GetRange(10, 3));
            run.RunEvents.Clear();
        }

        [Test]
        public void testFstHeader()
        {
            Trial trial = Fixtures.Fixtures.fstLightTrial;
            Run run = Fixtures.Fixtures.createLightFstRun(trial);
            ExportRun exportRun = ExportRun.Create(run, new ExportSettings(trial));

            Assert.AreEqual(15, run.Trial.Duration);
            Assert.AreEqual(11, run.RunEvents.Count);
            Assert.AreEqual(2.1, run.RunEvents[1].TimeTrackedInSeconds);

            List<string> headers = exportRun.Headers();
            List<string> expectedSubjectHeaders = new List<string>(){
                "Project", "SubjectID", "SubjectGroup", "Strain", "Sex",
                "TrialName", "TrialDuration", "DateRun", "TimeRun"
            };
            List<string> expectedDurationHeaders = new List<string>(){
                "Climbing Duration", "Swimming Duration", "Floating Duration", "Diving Duration"
            };
            List<string> expectedDetkeScoringHeaders = new List<string>(){
                "Climbing Score", "Swimming Score", "Floating Score", "Diving Score"
            };

            // standard, duration, frequency, latency, detke
            Assert.AreEqual(10 + 4 + 5 + 4 + 4, headers.Count, "Items on FST header output");
            Assert.AreEqual(expectedSubjectHeaders, headers.GetRange(0, 9));
            Assert.AreEqual(expectedDurationHeaders, headers.GetRange(10, 4));
            Assert.AreEqual(expectedDetkeScoringHeaders, headers.GetRange(23, 4));
            run.RunEvents.Clear();
        }

        [Test]
        public void testFstData()
        {
            Trial trial = Fixtures.Fixtures.fstTrial;
            Run run = Fixtures.Fixtures.createLightFstRun(trial);
            ExportRun exportRun = ExportRun.Create(run, new ExportSettings(trial));

            Assert.IsInstanceOf(typeof(ExportFstRun), exportRun);
            List<string> data = exportRun.RunData();
            List<string> expectedSubjectData = new List<string>(){
                "UnitTest Project", run.Subject.ToString(), "", null, null,
                run.Trial.ToString(), run.Trial.Duration.ToString()
            };
            List<string> expectedDurationData = new List<string>(){
                (286.5).ToString("F3"), (8.6).ToString("F3"),
                (4.9).ToString("F3"), (0).ToString("F3")
            };
            List<string> expectedFrequencyData = new List<string>(){
                (2).ToString(), (4).ToString(),
                (3).ToString(), (0).ToString(), (2).ToString()
            };
            List<string> expectedDetkeScoringData = new List<string>(){
                (58).ToString(), (2).ToString(),
                (0).ToString(), (0).ToString()
            };

            Assert.AreEqual(27, data.Count, "Items on FST data output");
            Assert.AreEqual(expectedSubjectData, data.GetRange(0, 7));
            Assert.AreEqual("11", data[9], "Number Of Events");
            Assert.AreEqual(expectedDurationData, data.GetRange(10, 4), "Behavior Duration");
            Assert.AreEqual(expectedFrequencyData, data.GetRange(14, 5), "Frequency Duration");
            Assert.AreEqual(expectedDetkeScoringData, data.GetRange(23, 4), "Detke Scoring");
        }


        [Test]
        public void testExportRange()
        {
            Trial trial = Fixtures.Fixtures.fstTrial;
            Run run = Fixtures.Fixtures.createLightFstRun(trial);
            ExportRun exportRun = ExportRun.Create(run, new ExportSettings(trial, -1, 3, 8));

            Assert.IsInstanceOf(typeof(ExportFstRun), exportRun);
            List<string> data = exportRun.RunData();

            List<string> expectedDurationData = new List<string>(){
                (0.3).ToString("F3"), (2.4).ToString("F3"),
                (2.3).ToString("F3"), (0).ToString("F3")
            };
            List<string> expectedFrequencyData = new List<string>(){
                (1).ToString(), (2).ToString(),
                (1).ToString(), (0).ToString(), (1).ToString()
            };
            List<string> expectedDetkeScoringData = new List<string>(){
                (0).ToString(), (1).ToString(),
                (0).ToString(), (0).ToString()
            };

            Assert.AreEqual(27, data.Count, "Items on FST data output");
            Assert.AreEqual("5", data[9], "Number Of Events");
            Assert.AreEqual(expectedDurationData, data.GetRange(10, 4), "Behavior Duration");
            Assert.AreEqual(expectedFrequencyData, data.GetRange(14, 5), "Frequency Duration");
            Assert.AreEqual(expectedDetkeScoringData, data.GetRange(23, 4), "Detke Scoring");
            run.RunEvents.Clear();
        }

        [Test]
        public void testTimeBins()
        {
            Trial trial = Fixtures.Fixtures.fstLightTrial;
            Run run = Fixtures.Fixtures.createLightFstRun(trial);

            ExportTimeBin exportTimeBin = new ExportTimeBin(run, 5);
            List<TimeBin> timeBins = exportTimeBin.calculateTimeBins();

            // initialization
            Assert.AreEqual(3, timeBins.Count);
            Assert.AreEqual(5000, timeBins[1].start);
            Assert.AreEqual(10000, timeBins[1].end);

            // calculation
            Assert.AreEqual(3800, timeBins[0].stateBehaviorTotalDuration[Fixtures.Fixtures.FstSwimming]);

            // export runData
            List<string> headers = exportTimeBin.headers();
            Assert.AreEqual(12, headers.Count);
            Assert.AreEqual("Climbing 0-5", headers[0]);
            Assert.AreEqual("Climbing 5-10", headers[1]);
            Assert.AreEqual("Swimming 0-5", headers[3]);
            Assert.AreEqual("Diving 10-15", headers[11]);

            // export data
            List<string> data = exportTimeBin.data();
            Assert.AreEqual(12, data.Count);
            Assert.AreEqual((1.2).ToString("F3"), data[0]);
            Assert.AreEqual((0.0).ToString("F3"), data[1]);
            Assert.AreEqual((3.8).ToString("F3"), data[3]);
            Assert.AreEqual((0.0).ToString("F3"), data[11]);

            //Exporter exporter = new Exporter(new ExportSettings(5));
            //exporter.export(run);
            run.RunEvents.Clear();
        }
    }
}