using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Trial : ActiveRecordBase<Trial>
    {
        public virtual int Id { get; set; }
        public virtual Session Session { get; set; }
        public virtual string Name { get; set; }
        public virtual Int32 Duration { get; set; }
        public virtual DateTime Tm { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
