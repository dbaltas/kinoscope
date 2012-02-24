using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;
using ObLib;

namespace observador
{
    public partial class DashBoard : ObWin.Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bCreateDatabase_Click(object sender, EventArgs e)
        {
            NHibernateHelper.BuildSchema();
            SeedData.AddInitialData();
            Application.Exit();
        }

        private void researchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowResearcherListForm();
        }

        private void createDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NHibernateHelper.BuildSchema();
            SeedData.AddInitialData();
        }

        private void subjectGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Researcher.Current.ActiveProject == null)
            {
                MessageBox.Show("Please create a project first.");
                return;
            }

            ShowSubjectGroupListForm();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Researcher.Current.ActiveProject == null)
            {
                MessageBox.Show("Please create a project first.");
                return;
            }

            ShowSubjectListForm();
        }

        private void bResearchers_Click(object sender, EventArgs e)
        {
            ShowResearcherListForm();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();

            if (!login.IsUserAuthenticated)
            {
                Application.Exit();
            }
            if (Researcher.Current != null)
            {
                tssResearcher.Text = String.Format("Researcher {0} logged in", Researcher.Current.Username);

                FillProjectsMenu();
                DisplayActiveProject();
            }
        }

        private void DisplayActiveProject()
        {
            Project activeProject = Researcher.Current.ActiveProject;

            // Set text in main window's Title Bar
            Text = string.Format(
                "{0} - {1}",
                activeProject == null ? "No project selected" : activeProject.Name,
                Program.GetTitle());
        }

        #region List forms

        private void ShowResearcherListForm()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "id" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Username", HeaderText = "username" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "ProjectCount", HeaderText = "projects" }};

            Form form = new ListForm<Researcher>(
                columns,
                Researcher.All,
                (item) => new AdminResearcherForm(item)) { ItemTypeDescription = "researcher", Text = "Researchers" };

            form.ShowDialog();
        }

        private void ShowProjectListForm()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "id" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "name" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Tm", HeaderText = "Date Created" }};

            Form form = new ListForm<Project>(
                columns,
                () => (IList)Researcher.Current.Projects,
                (item) => new ProjectForm(item)) { ItemTypeDescription = "project", Text = "My Projects" };

            form.ShowDialog();
        }

        private static void ShowSubjectGroupListForm()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "id" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "name" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Tm", HeaderText = "Date Created" }};

            Form form = new ListForm<SubjectGroup>(
                columns,
                () => (IList)Researcher.Current.ActiveProject.SubjectGroups,
                (item) => new SubjectGroupForm(item)) { ItemTypeDescription = "subject group", Text = "Subject Groups" };

            form.ShowDialog();
        }

        private static void ShowSubjectListForm()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "id" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "SubjectGroup", HeaderText = "subject group" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Code", HeaderText = "code" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Strain", HeaderText = "strain" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Sex", HeaderText = "sex" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "DateOfBirth", HeaderText = "DOB" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Tm", HeaderText = "Date Created" }};

            Form form = new ListForm<Subject>(
                columns,
                () => (IList)Researcher.Current.ActiveProject.Subjects,
                (item) => new SubjectForm(item)) { ItemTypeDescription = "subject", Text = "Subjects" };

            form.ShowDialog();
        }

        #endregion

        #region Projects menu

        private void FillProjectsMenu()
        {
            myProjectsToolStripMenuItem.DropDownItems.Clear();

            ToolStripMenuItem manageProjectsToolStripMenuItem = new ToolStripMenuItem();
            manageProjectsToolStripMenuItem.Text = "Manage Projects";
            manageProjectsToolStripMenuItem.Click += manageProjectsToolStripMenuItem_Click;


            foreach (Project project in Researcher.Current.Projects)
            {
                ToolStripMenuItem projectToolStripMenuItem = new ToolStripMenuItem(project.Name);
                projectToolStripMenuItem.Checked = project == Researcher.Current.ActiveProject;
                projectToolStripMenuItem.Click += projectItem_Click;
                projectToolStripMenuItem.Tag = project;
                myProjectsToolStripMenuItem.DropDownItems.Add(projectToolStripMenuItem);
            }

            if (Researcher.Current.Projects.Count > 0)
            {
                myProjectsToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            }

            myProjectsToolStripMenuItem.DropDownItems.Add(manageProjectsToolStripMenuItem);
        }

        private void manageProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowProjectListForm();

            FillProjectsMenu();
            DisplayActiveProject();
        }

        void projectItem_Click(object sender, EventArgs e)
        {
            Project selectedProject = (Project)((ToolStripMenuItem)sender).Tag;
            if (selectedProject != Researcher.Current.ActiveProject)
            {
                Researcher.Current.ActiveProject = selectedProject;
                FillProjectsMenu();
                DisplayActiveProject();
            }
        }

        #endregion
    }
}
