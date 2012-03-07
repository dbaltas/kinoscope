using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Behavior : ActiveRecordBase<Behavior>
    {
        public enum BehaviorType { State, Instant }

        private string _defaultKeyStroke;

        public virtual string Name { get; set; }
        public virtual BehaviorType Type { get; set; }
        public virtual BehavioralTestType BehavioralTestType { get; set; }
        public virtual string DefaultKeyStroke
        {
            get
            {
                return _defaultKeyStroke;
            }
            set
            {
                _defaultKeyStroke = value;
                if (KeyStroke == null)
                {
                    KeyStroke = value;
                }
            }
        }
        public virtual IList<ResearcherBehaviorKeyStroke> ResearcherBehaviorKeyStrokes { get; set; }

        public virtual string KeyStroke { get; set; }

        public Behavior()
        {
            ResearcherBehaviorKeyStrokes = new List<ResearcherBehaviorKeyStroke>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
