using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class EntityTemplate : ActiveRecordBase<EntityTemplate>
    {
        public enum EntityType { BehavioralTest };

        public virtual EntityType Entity { get; set; }
        public virtual String Name { get; set; }
        public virtual String Template { get; set; }

        public EntityTemplate()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual void UpdateAndSave(BehavioralTestType behavioralTestType, string name, int duration)
        {
            BehavioralTest behavioralTest = GetAsBehavioralTest(this);
            behavioralTest.BehavioralTestType = behavioralTestType;
            behavioralTest.Name = name;
            behavioralTest.Sessions[0].Trials[0].Duration = duration;

            SaveBehavioralTest(behavioralTest);
        }

        public virtual void SaveBehavioralTest(BehavioralTest behavioralTest)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(behavioralTest.GetType());

            string template;
            using (System.IO.StringWriter stringWriter = new System.IO.StringWriter())
            {
                x.Serialize(stringWriter, behavioralTest);
                template = stringWriter.ToString();
            }


            Name = behavioralTest.Name;
            Entity = EntityType.BehavioralTest;
            Template = template;
            Save();
        }

        public static EntityTemplate CreateSingleSessionSingleTrialTemplate(BehavioralTestType behavioralTestType, string name, int duration)
        {
            BehavioralTest test = new BehavioralTest();
            Session session = new Session();
            Trial trial = new Trial();

            test.BehavioralTestType = behavioralTestType;
            test.Name = name;
            trial.Duration = duration;
            session.TrialsForSerialization.Add(trial);
            test.SessionsForSerialization.Add(session);

            EntityTemplate entityTemplate = new EntityTemplate();
            entityTemplate.SaveBehavioralTest(test);
            return entityTemplate;
        }

        public static BehavioralTest GetAsBehavioralTest(EntityTemplate entityTemplate)
        {
            BehavioralTest test = new BehavioralTest();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(test.GetType());

            using (System.IO.StringReader stringReader = new System.IO.StringReader(entityTemplate.Template))
            {
                test = (BehavioralTest)x.Deserialize(stringReader);
            }
            foreach (Session s in test.SessionsForSerialization)
            {
                test.Sessions.Add(s);
                foreach (Trial t in s.TrialsForSerialization)
                {
                    s.Trials.Add(t);
                }
            }

            return test;
        }
    }
}
