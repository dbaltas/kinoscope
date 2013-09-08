using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DbMigrations;
using ObLib.Domain;


namespace ObLibTest.Fixtures
{
    class Fixtures
    {
        public static Behavior FstSwimming = null;
        public static Behavior FstClimbing = null;
        public static Behavior FstFloating = null;
        public static Behavior FstDiving = null;
        public static Behavior FstHeadSwinging = null;
        public static Behavior OrObjectA = null;
        public static Behavior OrObjectB = null;
        public static Behavior OrGeneralArea = null;

        public static BehavioralTest fstLightTest;
        public static Trial fstLightTrial;
        public static BehavioralTest fstTest;
        public static Trial fstTrial;
        public static BehavioralTest orTest;
        public static Trial orTrial;

        public static void setup()
        {
            DbMigrations.MigrationManager migrationManager = new DbMigrations.MigrationManager();
            migrationManager.MigrateToLastRevision();

            Researcher researcher = Researcher.Find("admin");
            Researcher.Current = researcher;

            Researcher.Current.ActiveProject = createLightFstProject();
            initializeBehaviors();
        }

        public static Run createLightFstRun(Trial trial)
        {
            Run run = trial.Runs[0];

            run.RunEvents.Clear();

            addRunEvent(run, FstSwimming, 0);
            addRunEvent(run, FstClimbing, 2100);
            addRunEvent(run, FstHeadSwinging, 3100);
            addRunEvent(run, FstSwimming, 3300);
            addRunEvent(run, FstFloating, 5200);
            addRunEvent(run, FstSwimming, 7500);
            addRunEvent(run, FstFloating, 11300);
            addRunEvent(run, FstSwimming, 12500);
            addRunEvent(run, FstHeadSwinging, 12800);
            addRunEvent(run, FstFloating, 13300);
            addRunEvent(run, FstClimbing, 14700);

            run.TmRun = DateTime.Now;
            run.Trial.Save();
            return run;
        }

        public static Run createObjectRecognitionRun(Trial trial)
        {
            Run run = trial.Runs[0];

            run.RunEvents.Clear();

            addRunEvent(run, OrGeneralArea, 0);
            addRunEvent(run, OrObjectA, 1100);
            addRunEvent(run, OrGeneralArea, 2000);
            addRunEvent(run, OrObjectA, 3200);
            addRunEvent(run, OrGeneralArea, 4600);
            addRunEvent(run, OrObjectB, 7500);
            addRunEvent(run, OrGeneralArea, 8400);
            addRunEvent(run, OrObjectA, 12000);
            addRunEvent(run, OrGeneralArea, 13200);
            addRunEvent(run, OrObjectB, 18100);
            addRunEvent(run, OrGeneralArea, 19200);
            addRunEvent(run, OrObjectA, 21700);
            addRunEvent(run, OrGeneralArea, 22200);

            run.TmRun = DateTime.Now;
            run.Trial.Save();
            return run;
        }

        private static Project createLightFstProject()
        {
            Project project = new Project();
            Researcher.Current.ActiveProject = project; //needed due to trial.populateWithRuns dependency on ActiveProject
            project.Name = "UnitTest Project";

            Subject subject = new Subject();
            subject.Code = "1";
            project.AddSubject(subject);
            Subject subject2 = new Subject();
            subject2.Code = "2";
            project.AddSubject(subject2);
            project.Save();

            fstLightTest = new BehavioralTest();
            Session fstLightSession = new Session();
            fstLightTrial = new Trial();
            fstLightTrial.Duration = 15;
            fstLightTrial.Name = "T1";
            fstLightTrial.PopulateWithRuns();

            fstLightSession.Name = "S1";
            fstLightSession.AddTrial(fstLightTrial);

            fstLightTest.Name = "FST light";
            fstLightTest.BehavioralTestType = BehavioralTestType.Fst;
            fstLightTest.AddSession(fstLightSession);

            project.AddBehavioralTest(fstLightTest);

            fstTest = new BehavioralTest();
            Session session = new Session();
            fstTrial = new Trial();
            fstTrial.Duration = 300;
            fstTrial.Name = "T1";
            fstTrial.PopulateWithRuns();

            session.Name = "S1";
            session.AddTrial(fstTrial);

            fstTest.Name = "FST Regular";
            fstTest.BehavioralTestType = BehavioralTestType.Fst;
            fstTest.AddSession(session);

            project.AddBehavioralTest(fstTest);

            orTest = new BehavioralTest();
            Session orSession = new Session();
            orTrial = new Trial();
            orTrial.Duration = 100;
            orTrial.Name = "T1";
            orTrial.PopulateWithRuns();

            orSession.Name = "S1";
            orSession.AddTrial(orTrial);

            orTest.Name = "Object Recognition";
            orTest.BehavioralTestType = BehavioralTestType.ObjectRecognition;
            orTest.AddSession(orSession);

            project.AddBehavioralTest(orTest);

            project.Save();
            return project;
        }

        private static void initializeBehaviors()
        {
            List<Behavior> behaviors = fstLightTest.GetBehaviors();

            foreach (Behavior behavior in behaviors)
            {
                if ("Swimming" == behavior.Name)
                {
                    FstSwimming = behavior;
                }
                if ("Climbing" == behavior.Name)
                {
                    FstClimbing = behavior;
                }
                if ("Floating" == behavior.Name)
                {
                    FstFloating = behavior;
                }
                if ("Diving" == behavior.Name)
                {
                    FstDiving = behavior;
                }
                if ("Head Swinging" == behavior.Name)
                {
                    FstHeadSwinging = behavior;
                }
            }

            List<Behavior> orBehaviors = orTest.GetBehaviors();

            foreach (Behavior behavior in orBehaviors)
            {
                if ("Object A" == behavior.Name)
                {
                    OrObjectA = behavior;
                }
                if ("Object B" == behavior.Name)
                {
                    OrObjectB = behavior;
                }
                if ("General Area" == behavior.Name)
                {
                    OrGeneralArea = behavior;
                }
            }

        }

        private static void addRunEvent(Run run, Behavior behavior, long timeTracked)
        {
            RunEvent runEvent = new RunEvent();
            runEvent.TimeTracked = timeTracked;
            runEvent.Behavior = behavior;
            run.AddRunEvent(runEvent);
        }
    }
}
