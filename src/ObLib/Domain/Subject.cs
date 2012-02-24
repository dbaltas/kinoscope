using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Subject : ActiveRecordBase<Subject>
    {
        public virtual int Id { get; set; }
        public virtual Project Project { get; set; }
        public virtual SubjectGroup SubjectGroup { get; set; }
        public virtual string Code { get; set; }
        public virtual string Strain { get; set; }
        public virtual string Sex { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string Origin { get; set; }
        public virtual Decimal? Weight { get; set; }
        public virtual DateTime Tm { get; set; }

        public override void Delete()
        {
            Project.Subjects.Remove(this);
            if (SubjectGroup != null)
            {
                SubjectGroup.Subjects.Remove(this);
            }
            Project.Save();
        }

        public override string ToString()
        {
            return Code;
        }
    }
}
