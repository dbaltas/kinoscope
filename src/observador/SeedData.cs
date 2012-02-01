using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;
using ObLib.Repositories;

namespace observador
{
    class SeedData
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
                Type = Behavior.TypeState
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Swimming",
                DefaultKeyStroke = "2",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.TypeState
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Floating",
                DefaultKeyStroke = "3",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.TypeState
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Diving",
                DefaultKeyStroke = "4",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.TypeState
            };
            behavior.Save();

            behavior = new Behavior
            {
                Name = "Head Swinging",
                DefaultKeyStroke = "5",
                BehavioralTestType = behavioralTestType,
                Type = Behavior.TypeInstant
            };
            behavior.Save();

            InsertProject();
        }

        static private void InsertProject()
        {
            Random rnd = new Random();
            var researcher = new Researcher { Username = "John" + rnd.Next(1, 10000).ToString(), Password = "123" };

            var project = new Project { Name = "my project" + rnd.Next(1, 10000).ToString() };
            //var behavioralTestType = null;// NHibernateHelper.OpenSession().Get<BehavioralTestType>(1);
            var behavioralTest = new BehavioralTest { Name = "first test", Project = project};

            project.AddBehavioralTest(behavioralTest);
            researcher.AddProject(project);

            researcher.Save();
        }
    }
}
