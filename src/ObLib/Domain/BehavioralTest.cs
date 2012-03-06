using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class BehavioralTest : ActiveRecordBase<BehavioralTest>
    {
        public virtual int Id { get; set; }
        public virtual Project Project { get; set; }
        public virtual BehavioralTestType BehavioralTestType { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Tm { get; set; }
        public virtual IList<Session> Sessions { get; set; }

        public BehavioralTest()
        {
            Sessions = new List<Session>();
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
                    // TODO: Modify behavior.KeyStroke based on current Researcher's ResearcherBehaviorKeyStrokes.
                    behaviors.Add(behavior);
                }
            }

            return behaviors;
        }
    }
}
