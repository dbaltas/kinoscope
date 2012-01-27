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
    }
}
