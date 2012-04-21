using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Session : ActiveRecordBase<Session>
    {
        public virtual BehavioralTest BehavioralTest { get; set; }
        public virtual string Name { get; set; }
        [System.Xml.Serialization.XmlIgnore()]
        public virtual IList<Trial> Trials { get; set; }
        public virtual List<Trial> TrialsForSerialization { get; set; }

        public Session()
        {
            Trials = new List<Trial>();
            TrialsForSerialization = new List<Trial>();
        }

        public virtual void AddTrial(Trial trial)
        {
            trial.Session = this;
            Trials.Add(trial);
        }

        public override string ToString()
        {
            if (BehavioralTest.Sessions.Count > 1)
            {
                return String.Format("{0}:{1}", BehavioralTest.Name, Name);
            }
            else
            {
                return String.Format("{0}", BehavioralTest.Name);
            }
        }
    }
}
