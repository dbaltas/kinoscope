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
        public static Behavior swimming = null;
        public static Behavior climbing = null;
        public static Behavior floating = null;

        public static BehavioralTest fstTest;
        public static Trial fstTrial;

        public static void setup()
        {
            DbMigrations.MigrationManager migrationManager = new DbMigrations.MigrationManager();
            migrationManager.MigrateToLastRevision();

            Researcher researcher = Researcher.Find("admin");
            Researcher.Current = researcher;
            Project project = new Project();
            project.Name = "UnitTest Project";
            researcher.ActiveProject = project;

            Subject subject = new Subject();
            subject.Code = "1";
            project.AddSubject(subject);
            Subject subject2 = new Subject();
            subject2.Code = "2";
            project.AddSubject(subject2);
            project.Save();

            fstTest = new BehavioralTest();
            Session session = new Session();
            fstTrial = new Trial();
            fstTrial.Duration = 15;
            fstTrial.Name = "T1";
            fstTrial.PopulateWithRuns();

            session.Name = "S1";
            session.AddTrial(fstTrial);

            fstTest.Name = "FST light";
            fstTest.BehavioralTestType = BehavioralTestType.Fst;
            fstTest.AddSession(session);

            project.AddBehavioralTest(fstTest);

            project.Save();

            initializeFstBehaviors();
        }

        public static Run createSampleRun(Trial trial)
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
            run.Trial.Save();
            return run;
        }

        private static void addRunEvent(Run run, Behavior behavior, long timeTracked)
        {
            RunEvent runEvent = new RunEvent();
            runEvent.TimeTracked = timeTracked;
            runEvent.Behavior = behavior;
            run.AddRunEvent(runEvent);
        }

        private static void initializeFstBehaviors()
        {
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
    }
}
