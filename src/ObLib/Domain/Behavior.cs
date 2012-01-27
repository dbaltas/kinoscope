using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
	public class Behavior : ActiveRecordBase<Behavior>
	{
        public const string TypeState = "State";
        public const string TypeInstant = "Instant";

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
        public virtual BehavioralTestType BehavioralTestType { get; set; }
        public virtual string DefaultKeyStroke { get; set; }
        public virtual DateTime Tm { get; set; }
	}
}
