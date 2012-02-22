using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;
using ObLib;

using ObWin;

namespace observador
{
    public partial class DashBoard : ObWin.Form
    {
        private const string title = "Observador v0.0";

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
            AdminResearcherListForm form = new AdminResearcherListForm();
            form.Show();
        }

        private void createDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NHibernateHelper.BuildSchema();
            SeedData.AddInitialData();
        }

        private void subjectGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectGroupListForm form = new SubjectGroupListForm();
            form.Show();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented");
        }

        private void bResearchers_Click(object sender, EventArgs e)
        {
            AdminResearcherListForm form = new AdminResearcherListForm();
            form.Show();
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
                title);
        }

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
            ProjectListForm form = new ProjectListForm();
            form.ShowDialog();

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
