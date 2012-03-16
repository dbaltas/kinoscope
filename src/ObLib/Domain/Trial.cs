using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Trial : ActiveRecordBase<Trial>
    {
        public virtual Session Session { get; set; }
        public virtual string Name { get; set; }
        public virtual int Duration { get; set; }
        public virtual IList<Run> Runs { get; set; }
        public virtual int CompleteRunCount
        {
            get
            {
                return Runs.Count(r => r.Status == Run.RunStatus.Complete);
            }
        }

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

        /// <summary>
        /// Adds a run to this trial for every project's subject 
        /// for which a run does not already exist for this trial.
        /// </summary>
        public virtual void PopulateWithRuns()
        {
            foreach (Subject subject in Researcher.Current.ActiveProject.Subjects)
            {
                if (!Runs.Any((run) => run.Subject.Code == subject.Code))
                {
                    AddRun(new Run() { Subject = subject });
                }
            }
        }
    }
}
