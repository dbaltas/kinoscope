using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace observador
{
    public class ListFormCreator
    {
        public Form CreateResearcherListForm()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Username", HeaderText = "User Name" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "ProjectCount", HeaderText = "Projects" }};

            return new ListForm<Researcher>(
                columns,
                Researcher.All,
                (item) => new AdminResearcherForm(item)) { ItemTypeDescription = "researcher", Text = "Researchers" };
        }

        public Form CreateProjectListForm()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "TmCreated", HeaderText = "Date Created" }};

            return new ListForm<Project>(
                columns,
                () => (IList)Researcher.Current.Projects,
                (item) => new ProjectForm(item)) { ItemTypeDescription = "project", Text = "My Projects" };
        }

        public Form CreateSubjectGroupListForm()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "SubjectCount", HeaderText = "Subjects" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "TmCreated", HeaderText = "Date Created" }};

            return new ListForm<SubjectGroup>(
                columns,
                () => (IList)Researcher.Current.ActiveProject.SubjectGroups,
                (item) => new SubjectGroupForm(item)) { ItemTypeDescription = "subject group", Text = "Subject Groups" };
        }

        public Form CreateSubjectListForm()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "SubjectGroup", HeaderText = "Subject Group" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Code", HeaderText = "Code" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Strain", HeaderText = "Strain" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Sex", HeaderText = "Sex" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "DateOfBirth", HeaderText = "DOB" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "TmCreated", HeaderText = "Date Created" }};

            return new ListForm<Subject>(
                columns,
                () => (IList)Researcher.Current.ActiveProject.Subjects,
                (item) => new SubjectForm(item)) { ItemTypeDescription = "subject", Text = "Subjects", Width = 900 };
        }

        public Form CreateResearcherBehaviorKeyStrokeListForm()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Behavior", HeaderText = "Behavior" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "BehavioralTestType", HeaderText = "Behavioral Test Type" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "KeyStroke", HeaderText = "Key Stroke" }};

            return new ListForm<ResearcherBehaviorKeyStroke>(
                columns,
                () => (IList)Researcher.Current.ResearcherBehaviorKeyStrokes,
                (item) => new ResearcherBehaviorKeyStrokeForm(item))
                {
                    ItemTypeDescription = "key stroke",
                    Text = "Behavior Key Strokes"
                };
        }
    }
}
