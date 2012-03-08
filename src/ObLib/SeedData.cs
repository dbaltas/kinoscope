using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace ObLib
{
    public class SeedData
    {
        static public void AddInitialData()
        {
            var behavioralTestType = new BehavioralTestType { Name = "FST", Description = "Forced Swimmend Test" };
            behavioralTestType.Save();

            var behavior = new Behavior
            {
                Name = "Climbing",
                DefaultKeyStroke = "1",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Swimming",
                DefaultKeyStroke = "2",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Floating",
                DefaultKeyStroke = "3",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Diving",
                DefaultKeyStroke = "4",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Head Swinging",
                DefaultKeyStroke = "5",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.Instant
            };
            behavior.Save();

            var researcher = new Researcher { Username = "admin", Password = "123" };
            researcher.Save();
        }


        public static void CreateDefaultFst(Researcher researcher, String name)
        {
            if (researcher == null)
            {
                Logger.logError("Invalid Researcher");
                return;
            }

            var project = new Project { Name = name };

            var preTest = new BehavioralTest
            {
                Name = "preTest",
                BehavioralTestType = BehavioralTestType.Fst,
            };
            project.AddBehavioralTest(preTest);

            var test = new BehavioralTest
            {
                Name = "test",
                BehavioralTestType = BehavioralTestType.Fst,
            };
            project.AddBehavioralTest(test);

            Researcher.Current.AddProject(project);

            var preTestSession = new Session
            {
                Name = "",
            };
            preTest.AddSession(preTestSession);

            var preTestTrial = new Trial
            {
                Name = "",
                Duration = 15 * 60,
            };
            preTestSession.AddTrial(preTestTrial);

            var testSession = new Session
            {
                Name = "",
            };
            test.AddSession(testSession);

            var testTrial = new Trial
            {
                Name = "for demo purposes",
                Duration = 10,
            };
            preTestSession.AddTrial(testTrial);

            var testTrial2 = new Trial
            {
                Name = "",
                Duration = 5 * 60,
            };
            testSession.AddTrial(testTrial2);

            Researcher.Current.Save();
        }

        static private void InsertProject()
        {
            Random rnd = new Random();
            var researcher = new Researcher { Username = "john" + rnd.Next(1, 10000).ToString(), Password = "123" };

            var project = new Project { Name = "my project" + rnd.Next(1, 10000).ToString() };
            //var behavioralTestType = null;// NHibernateHelper.OpenSession().Get<BehavioralTestType>(1);
            var behavioralTest = new BehavioralTest { Name = "first test", Project = project };

            project.AddBehavioralTest(behavioralTest);
            researcher.AddProject(project);

            researcher.Save();
        }
    }
}
