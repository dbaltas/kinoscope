using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class Project : ActiveRecordBase<Project>
    {
        public virtual string Name { get; set; }
        public virtual Researcher Researcher { get; set; }
        public virtual IList<BehavioralTest> BehavioralTests { get; set; }
        public virtual IList<Subject> Subjects { get; set; }
        public virtual IList<SubjectGroup> SubjectGroups { get; set; }

        public Project()
        {
            BehavioralTests = new List<BehavioralTest>();
            Subjects = new List<Subject>();
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

        public virtual void AddSubject(Subject subject)
        {
            subject.Project = this;
            Subjects.Add(subject);
        }

        public override void Delete()
        {
            Researcher.RemoveProject(this);
            Researcher.Save();
        }

        public override string ToString()
        {
            return Name;
        }


        public virtual IList<Trial> Trials
        {
            get
            {
                List<Trial> trials = new List<Trial>();
                foreach (BehavioralTest behavioralTest in BehavioralTests)
                {
                    foreach (Session session in behavioralTest.Sessions)
                    {
                        trials.AddRange(session.Trials);
                    }
                }
                return trials;
            }
        }

        public virtual IList<Run> CompleteRuns
        {
            get
            {
                List<Run> runs = new List<Run>();
                foreach (Trial trial in Trials)
                {
                    runs.AddRange(trial.Runs.Where((r) => r.Status == Run.RunStatus.Complete));
                }

                return runs;
            }
        }
    }
}
