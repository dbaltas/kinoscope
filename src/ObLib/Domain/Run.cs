using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ObLib.Domain
{
    public class Run : ActiveRecordBase<Run>
    {
        public enum RunStatus { NotRun, Complete }

        public virtual int Id { get; set; }
        public virtual Trial Trial { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual DateTime Tm { get; set; }
        public virtual IList<RunEvent> RunEvents { get; set; }

        public virtual RunStatus Status
        {
            get
            {
                return Tm > DateTime.MinValue ? RunStatus.Complete : RunStatus.NotRun;
            }
        }
        public virtual string StatusDescription
        {
            get
            {
                return Status == RunStatus.NotRun ? "Not Run" : Status.ToString();
            }
        }

        public Run()
        {
            RunEvents = new List<RunEvent>();
            Tm = DateTime.MinValue;
        }

        public virtual void AddRunEvent(RunEvent runEvent)
        {
            runEvent.Run = this;
            RunEvents.Add(runEvent);
        }

        public virtual void AddRunEvents(List<RunEvent> runEvents)
        {
            foreach (RunEvent runEvent in runEvents)
            {
                AddRunEvent(runEvent);
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Trial, Subject);
        }
    }
}
