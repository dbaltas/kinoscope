using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class BehavioralTestType : ActiveRecordBase<BehavioralTestType>
	{
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Tm { get; set; }
    }
}
