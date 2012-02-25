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
        public virtual IList<Trial> Trials { get; set; }

        public Session()
        {
            Trials = new List<Trial>();
        }

        public virtual void AddTrial(Trial trial)
        {
            trial.Session = this;
            Trials.Add(trial);
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", BehavioralTest.Name, Name);
        }
    }
}
