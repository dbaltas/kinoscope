using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace kinoscope
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
                new DataGridViewTextBoxColumn() { DataPropertyName = "Code", HeaderText = "Code" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "SubjectGroup", HeaderText = "Subject Group" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Strain", HeaderText = "Strain" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Sex", HeaderText = "Sex" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "DateOfBirth", HeaderText = "DOB" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "TmCreated", HeaderText = "Date Created" }};

            return new ListForm<Subject>(
                columns,
                () => (IList)Researcher.Current.ActiveProject.Subjects,
                (item) => new SubjectForm(item)) { ItemTypeDescription = "subject", Text = "Subjects", Width = 900 };
        }
    }
}
