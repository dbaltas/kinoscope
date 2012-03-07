using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class SubjectGroup : ActiveRecordBase<SubjectGroup>
    {
        public virtual Project Project { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Subject> Subjects { get; set; }
        public virtual int SubjectCount { get { return Subjects.Count; } }

        public SubjectGroup()
        {
            Subjects = new List<Subject>();
        }

        public virtual void AddSubject(Subject subject)
        {
            subject.SubjectGroup = this;
            Subjects.Add(subject);
        }

        public override void Delete()
        {
            foreach (Subject subject in Subjects)
            {
                subject.SubjectGroup = null;
                subject.Save();
            }

            Project.SubjectGroups.Remove(this);
            Project.Save();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
