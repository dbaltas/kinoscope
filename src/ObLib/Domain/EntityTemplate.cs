using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class EntityTemplate : ActiveRecordBase<EntityTemplate>
    {
        public virtual String Entity { get; set; }
        public virtual String Name { get; set; }
        public virtual String Template { get; set; }

        public EntityTemplate()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
