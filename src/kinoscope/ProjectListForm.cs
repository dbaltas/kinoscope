using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib;
using ObLib.Domain;

namespace kinoscope
{
    public class ProjectListForm : ListForm<Project>
    {
        public ProjectListForm()
            : base(
            new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "TmCreated", HeaderText = "Date Created" }},
                () => (IList)Researcher.Current.Projects,
                (item) => new ProjectForm(item))
        {
            ItemTypeDescription = "project";
            Text = "My Projects";
        }

        protected override void ItemEdit(Project project)
        {
            (new ProjectEditForm(project)).Show();
        }
    }
}
