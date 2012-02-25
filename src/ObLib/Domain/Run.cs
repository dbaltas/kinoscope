using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Run : ActiveRecordBase<Run>
    {
        public virtual int Id { get; set; }
        public virtual Trial Trial { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual DateTime Tm { get; set; }
        public virtual IList<RunEvent> RunEvents { get; set; }

        public Run()
        {
            RunEvents = new List<RunEvent>();
        }

        public virtual void AddRunEvent(RunEvent runEvent)
        {
            runEvent.Run = this;
            RunEvents.Add(runEvent);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Trial, Subject);
        }
    }
}
