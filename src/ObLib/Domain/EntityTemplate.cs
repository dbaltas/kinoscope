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

        public virtual void SaveBehavioralTest(BehavioralTest behavioralTest)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(behavioralTest.GetType());

                string template;

                behavioralTest.SessionsForSerialization.Clear();
                foreach (Session session in behavioralTest.Sessions)
                {
                    behavioralTest.SessionsForSerialization.Add(session);
                    foreach (Trial trial in session.Trials)
                    {
                        session.TrialsForSerialization.Add(trial);
                    }
                }

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
            catch (Exception exc)
            {
                if (exc.InnerException != null)
                {
                    exc = exc.InnerException;
                }
                Logger.logError(exc);
            }
        }

        public static BehavioralTest GetAsBehavioralTest(EntityTemplate entityTemplate)
        {
            BehavioralTest test = new BehavioralTest();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(test.GetType());

            using (System.IO.StringReader stringReader = new System.IO.StringReader(entityTemplate.Template))
            {
                test = (BehavioralTest)x.Deserialize(stringReader);
            }
            test.TmCreated = DateTime.Now;
            foreach (Session s in test.SessionsForSerialization)
            {
                test.Sessions.Add(s);
                s.TmCreated = DateTime.Now;
                foreach (Trial t in s.TrialsForSerialization)
                {
                    s.Trials.Add(t);
                    t.TmCreated = DateTime.Now;
                }
            }

            return test;
        }
    }
}
