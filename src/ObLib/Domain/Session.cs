using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Session : ActiveRecordBase<Session>
    {
        public virtual int Id { get; set; }
        public virtual BehavioralTest BehavioralTest { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Tm { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
