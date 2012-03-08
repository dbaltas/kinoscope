using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Subject : ActiveRecordBase<Subject>
    {
        public virtual Project Project { get; set; }
        public virtual SubjectGroup SubjectGroup { get; set; }
        public virtual string Code { get; set; }
        public virtual string Strain { get; set; }
        public virtual string Sex { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string Origin { get; set; }
        public virtual Decimal? Weight { get; set; }

        public virtual IList<Run> Runs { get; set; }

        public Subject()
        {
            Runs = new List<Run>();
        }

        public override void Delete()
        {
            if (SubjectGroup != null)
            {
                SubjectGroup.Subjects.Remove(this);
                SubjectGroup.Save();
            }

            Project.Subjects.Remove(this);
            Project.Save();
        }

        public override string ToString()
        {
            return Code;
        }

        public virtual Run RunForTrial(Trial trial)
        {
            foreach (Run run in trial.Runs)
            {
                if (run.Subject.Code == this.Code)
                {
                    return run;
                }
            }

            return null;
        }
    }
}
