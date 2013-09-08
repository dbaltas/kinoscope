using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ObLib.Domain
{
    public class Run : ActiveRecordBase<Run>
    {
        public class ValidationResult
        {
            public bool IsValid { get; set; }
            public string Error { get; set; }
        }

        public enum RunStatus { NotRun, Complete }

        public virtual DateTime TmRun { get; set; }
        public virtual Trial Trial { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual IList<RunEvent> RunEvents { get; set; }

        public virtual RunStatus Status
        {
            get
            {
                return TmRun > DateTime.MinValue ? RunStatus.Complete : RunStatus.NotRun;
            }
        }
        public virtual string StatusDescription
        {
            get
            {
                return Status == RunStatus.NotRun ? "Not Run" : Status.ToString();
            }
        }
        public virtual string DisplayForTrial
        {
            get
            {
                if (Id == -1)
                {
                    return "[please select]";
                }
                return String.Format("{0} ({1})", Subject, StatusDescription);
            }
        }

        public virtual List<RunEvent> SortedRunEvents
        {
            get
            {
                if (_sortedRunEvents == null)
                {
                    _sortedRunEvents = new List<RunEvent>(RunEvents);
                    _sortedRunEvents.Sort(new Comparison<RunEvent>((re1, re2) => (int)(re1.TimeTracked - re2.TimeTracked)));
                }
                return _sortedRunEvents;
            }
        }

        public virtual List<RunEvent> SortedStateRunEvents
        {
            get
            {
                if (_sortedStateRunEvents == null)
                {
                    _sortedStateRunEvents = SortedRunEvents.FindAll(new Predicate<RunEvent>(r => r.Behavior.Type == Behavior.BehaviorType.State));
                }
                return _sortedStateRunEvents;
            }
        }

        private List<RunEvent> _sortedRunEvents;
        private List<RunEvent> _sortedStateRunEvents;

        public Run()
        {
            RunEvents = new List<RunEvent>();
            TmRun = DateTime.MinValue;
        }

        public virtual void AddRunEvent(RunEvent runEvent)
        {
            runEvent.Run = this;
            RunEvents.Add(runEvent);
        }

        public virtual void SetRunEvents(List<RunEvent> runEvents)
        {
            this.RunEvents.Clear();

            foreach (RunEvent runEvent in runEvents)
            {
                AddRunEvent(runEvent);
            }
        }

        public override void Delete()
        {
            Trial.Runs.Remove(this);
            Trial.Save();
        }

        public virtual ValidationResult Validate()
        {
            if (!RunEvents.Any((re) => re.TimeTracked == 0 && re.Behavior.Type == Behavior.BehaviorType.State))
            {
                return new ValidationResult()
                {
                    IsValid = false,
                    Error = "This run contains no state behavior starting at the beginning of the run."
                };
            }

            return new ValidationResult() { IsValid = true };
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Trial, Subject);
        }
    }
}
