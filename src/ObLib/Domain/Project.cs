using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Project : ActiveRecordBase<Project>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Researcher Researcher { get; set; }
        public virtual DateTime Tm { get; set; }
        public virtual IList<BehavioralTest> BehavioralTests { get; set; }
        public virtual IList<Subject> Subjects { get; set; }
        public virtual IList<SubjectGroup> SubjectGroups { get; set; }

        public Project()
        {
            BehavioralTests = new List<BehavioralTest>();
            SubjectGroups = new List<SubjectGroup>();
        }

        public virtual void AddBehavioralTest(BehavioralTest behavioralTest)
        {
            behavioralTest.Project = this;
            BehavioralTests.Add(behavioralTest);
        }

        public virtual void AddSubjectGroup(SubjectGroup subjectGroup)
        {
            subjectGroup.Project = this;
            SubjectGroups.Add(subjectGroup);
        }

        public virtual void AddSubjects(Subject subject)
        {
            subject.Project = this;
            Subjects.Add(subject);
        }
    }
}
