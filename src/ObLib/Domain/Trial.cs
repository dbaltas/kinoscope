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
        public virtual IList<Run> Runs { get; set; }
        public virtual int RunCount { get { return Runs.Count; } }

        public Trial()
        {
            Runs = new List<Run>();
        }

        public virtual void AddRun(Run run)
        {
            run.Trial = this;
            Runs.Add(run);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
