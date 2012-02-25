﻿using System;
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
                /* TODO: should return all trials of all behavioral tests*/
                return this.BehavioralTests[0].Sessions[0].Trials;
            }
        }
    }
}
