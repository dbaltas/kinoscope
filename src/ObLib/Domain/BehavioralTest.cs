using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class BehavioralTest : ActiveRecordBase<BehavioralTest>
    {
        [System.Xml.Serialization.XmlIgnore()]
        public virtual Project Project { get; set; }
        public virtual BehavioralTestType BehavioralTestType { get; set; }
        public virtual string Name { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public virtual IList<Session> Sessions { get; set; }
        public virtual List<Session> SessionsForSerialization { get; set; }

        public BehavioralTest()
        {
            Sessions = new List<Session>();
            SessionsForSerialization = new List<Session>();
        }

        public virtual void AddSession(Session session)
        {
            session.BehavioralTest = this;
            Sessions.Add(session);
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual List<Behavior> GetBehaviors()
        {
            List<Behavior> behaviors = new List<Behavior>();

            BehavioralTestType behavioralTestType = BehavioralTestType;
            foreach (Behavior behavior in Behavior.All())
            {
                if (behavior.BehavioralTestType == behavioralTestType)
                {
                    ResearcherBehaviorKeyStroke researcherBehaviorKeyStroke
                        = Researcher.Current.ResearcherBehaviorKeyStrokes.FirstOrDefault(
                            (item) => item.Behavior.Id == behavior.Id
                        );

                    if (researcherBehaviorKeyStroke != null)
                    {
                        behavior.KeyStroke = researcherBehaviorKeyStroke.KeyStroke;
                    }

                    behaviors.Add(behavior);
                }
            }

            return behaviors;
        }

        public virtual List<Run> GetRuns()
        {
            List<Run> runList = new List<Run>();
            foreach (Session session in Sessions)
            {
                foreach (Trial trial in session.Trials)
                {
                    foreach (Run run in trial.Runs)
                    {
                        if (run.Status == Run.RunStatus.Complete)
                        {
                            runList.Add(run);
                        }
                    }
                }
            }
            return runList;
        }
    }
}
