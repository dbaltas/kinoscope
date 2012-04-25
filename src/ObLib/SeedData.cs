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
            _FstBehavioralTestTypeAndBehaviors();
            ObjectRecognitionBehavioralTestTypeAndBehaviors();
            PlusMazeBehavioralTestTypeAndBehaviors();
            var researcher = new Researcher { Username = "admin", Password = "123" };
            researcher.Save();
        }

        private static void _FstBehavioralTestTypeAndBehaviors()
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
        }

        public static void ObjectRecognitionBehavioralTestTypeAndBehaviors()
        {
            var behavioralTestType = new BehavioralTestType { Name = "Object Recognition", Description = "Object Recognition" };
            behavioralTestType.Save();

            var behavior = new Behavior
            {
                Name = "Object A",
                DefaultKeyStroke = "1",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Object B",
                DefaultKeyStroke = "2",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "General Area",
                DefaultKeyStroke = "3",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();
        }

        public static void PlusMazeBehavioralTestTypeAndBehaviors()
        {
            var behavioralTestType = new BehavioralTestType { Name = "EPM", Description = "Elevated Plus Maze" };
            behavioralTestType.Save();

            var behavior = new Behavior
            {
                Name = "North Entry",
                DefaultKeyStroke = "1",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "South Entry",
                DefaultKeyStroke = "2",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "West Entry",
                DefaultKeyStroke = "3",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "East Entry",
                DefaultKeyStroke = "4",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Center Entry",
                DefaultKeyStroke = "5",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.State
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Incomplete Closed Entry",
                DefaultKeyStroke = "6",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.Instant
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Incomplete Open Entry",
                DefaultKeyStroke = "7",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.Instant
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Incomplete Center Entry",
                DefaultKeyStroke = "8",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.Instant
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Protected Head Dip",
                DefaultKeyStroke = "9",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.Instant
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Unprotected Head Dip",
                DefaultKeyStroke = "0",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.BehaviorType.Instant
            };
            behavior.Save();
        }

        public static Project CreateDefaultFst(Researcher researcher, String name)
        {
            if (researcher == null)
            {
                Logger.logError("Invalid Researcher");
                return null;
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

            var testTrial2 = new Trial
            {
                Name = "",
                Duration = 5 * 60,
            };
            testSession.AddTrial(testTrial2);

            Researcher.Current.Save();

            return project;
        }

        public static Project CreateDefaultEpm(Researcher researcher, String name)
        {
            if (researcher == null)
            {
                Logger.logError("Invalid Researcher");
                return null;
            }

            var project = new Project { Name = name };

            var test = new BehavioralTest
            {
                Name = "test",
                BehavioralTestType = BehavioralTestType.Epm,
            };

            project.AddBehavioralTest(test);

            Researcher.Current.AddProject(project);

            var testSession = new Session
            {
                Name = "",
            };
            test.AddSession(testSession);

            var testTrial = new Trial
            {
                Name = "",
                Duration = 300,
            };
            testSession.AddTrial(testTrial);

            Researcher.Current.Save();

            return project;
        }

        public static Project CreateDefaultObjectRecognition(Researcher researcher, String name)
        {
            if (researcher == null)
            {
                Logger.logError("Invalid Researcher");
                return null;
            }

            var project = new Project { Name = name };

            var test = new BehavioralTest
            {
                Name = "Test1",
                BehavioralTestType = BehavioralTestType.ObjectRecognition,
            };

            project.AddBehavioralTest(test);

            Researcher.Current.AddProject(project);

            var testSession = new Session
            {
                Name = "S1",
            };
            test.AddSession(testSession);

            var testTrial = new Trial
            {
                Name = "T1",
                Duration = 300,
            };
            testSession.AddTrial(testTrial);

            testTrial = new Trial
            {
                Name = "T2",
                Duration = 300,
            };
            testSession.AddTrial(testTrial);

            testTrial = new Trial
            {
                Name = "T3",
                Duration = 300,
            };
            testSession.AddTrial(testTrial);

            testSession = new Session
            {
                Name = "S2",
            };
            test.AddSession(testSession);

            testTrial = new Trial
            {
                Name = "T1",
                Duration = 300,
            };
            testSession.AddTrial(testTrial);

            testTrial = new Trial
            {
                Name = "T2",
                Duration = 300,
            };
            testSession.AddTrial(testTrial);

            testTrial = new Trial
            {
                Name = "T3",
                Duration = 300,
            };
            testSession.AddTrial(testTrial);


            Researcher.Current.Save();

            return project;
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
