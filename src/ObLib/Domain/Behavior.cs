using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Behavior : ActiveRecordBase<Behavior>
    {
        public enum BehaviorType { State, Instant }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual BehaviorType Type { get; set; }
        public virtual BehavioralTestType BehavioralTestType { get; set; }
        public virtual string DefaultKeyStroke { get; set; }
        public virtual DateTime Tm { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
