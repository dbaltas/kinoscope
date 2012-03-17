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

        public virtual void Export()
        {
            List<Behavior> allStateBehaviorsOnThisBehavioralType = new List<Behavior>();
            List<Behavior> allInstantBehaviorsOnThisBehavioralType = new List<Behavior>();

            foreach (Behavior behavior in this.Trial.Session.BehavioralTest.GetBehaviors())
            {
                switch (behavior.Type)
                {
                    case Behavior.BehaviorType.State:
                        allStateBehaviorsOnThisBehavioralType.Add(behavior);
                        break;
                    case Behavior.BehaviorType.Instant:
                        allInstantBehaviorsOnThisBehavioralType.Add(behavior);
                        break;
                }
            }

            Dictionary<Behavior, int> behaviorFrequency = new Dictionary<Behavior, int>();
            Dictionary<Behavior, long> stateBehaviorTotalDuration = new Dictionary<Behavior, long>();

            foreach (Behavior behavior in this.Trial.Session.BehavioralTest.GetBehaviors())
            {
                behaviorFrequency.Add(behavior, 0);
            }
            foreach (Behavior behavior in allStateBehaviorsOnThisBehavioralType)
            {
                stateBehaviorTotalDuration.Add(behavior, 0);
            }

            List<RunEvent> sortedRunEvents = new List<RunEvent>(RunEvents);
            sortedRunEvents.Sort(new Comparison<RunEvent>((re1, re2) => (int)(re1.TimeTracked - re2.TimeTracked)));

            RunEvent lastStateRunEvent = sortedRunEvents[0];
            foreach (RunEvent runEvent in sortedRunEvents)
            {
                behaviorFrequency[runEvent.Behavior]++;

                if (runEvent.TimeTracked == 0)
                {
                    continue;
                }

                if (runEvent.Behavior.Type == Behavior.BehaviorType.State)
                {
                    // State Behaviors tracked other than the first.
                    stateBehaviorTotalDuration[lastStateRunEvent.Behavior] += runEvent.TimeTracked - lastStateRunEvent.TimeTracked;
                    lastStateRunEvent = runEvent;
                }
            }
            // add the time left till the end of the run
            stateBehaviorTotalDuration[lastStateRunEvent.Behavior] += this.Trial.Duration * 1000 - lastStateRunEvent.TimeTracked;

            // EXPORTING
            List<string> headers = new List<string>();
            List<string> data = new List<string>();

            headers.Add("Project");
            headers.Add("SubjectID");
            headers.Add("SubjectGroup");
            headers.Add("Strain");
            headers.Add("Sex");
            headers.Add("TrialName");
            headers.Add("TrialDuration");
            headers.Add("DateRun");
            headers.Add("TimeRun");

            data.Add(this.Trial.Session.BehavioralTest.Project.ToString());
            data.Add(this.Subject.ToString());
            string subjectGroup = "";
            if (this.Subject.SubjectGroup != null)
            {
                subjectGroup = this.Subject.SubjectGroup.ToString();
            }
            data.Add(subjectGroup);
            data.Add(this.Subject.Strain);
            data.Add(this.Subject.Sex);
            data.Add(this.Trial.ToString());
            data.Add(this.Trial.Duration.ToString());
            data.Add(this.TmCreated.ToString("dd/MM/yyyy"));
            data.Add(this.TmCreated.ToString("HH:mm:ss"));

            foreach (var behaviorTotal in stateBehaviorTotalDuration)
            {
                headers.Add(behaviorTotal.Key.Name + " Duration");
                data.Add(behaviorTotal.Value.ToString());
            }

            foreach (var behaviorCount in behaviorFrequency)
            {
                headers.Add(behaviorCount.Key.Name + " Frequency");
                data.Add(behaviorCount.Value.ToString());
            }


            string headerRow = String.Join<String>("\t", headers);
            string dataRow = String.Join<String>("\t", data);

            string exportFilename = String.Format(@"{0}-{1}-{2}.csv",
                this.Trial.Session.BehavioralTest.Project,
                this.Trial,
                this.Subject);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(exportFilename))
            {
                file.WriteLine(headerRow);
                file.WriteLine(dataRow);
            }
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
