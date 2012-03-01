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
        private ListFormCreator _listFormCreator = new ListFormCreator();

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
            Cursor.Current = Cursors.WaitCursor;
            if (Researcher.Current != null)
            {
                Researcher.Current.Delete();
            }
            try
            {
                if (BehavioralTestType.Fst != null)
                {
                    BehavioralTestType.Fst.Delete();
                }

            }
            catch (Exception exception)
            {
                Logger.logError(exception.ToString());
            }
            NHibernateHelper.BuildSchema();
            SeedData.AddInitialData();
            MessageBox.Show("Database Created. Application will now restart");
            Application.Restart();
        }

        private void researchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listFormCreator.CreateResearcherListForm().ShowDialog();
        }

        private void createDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NHibernateHelper.BuildSchema();
            SeedData.AddInitialData();
        }

        private void trialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Researcher.Current.ActiveProject == null)
            {
                MessageBox.Show("Please create a project first.");
                return;
            }

            _listFormCreator.CreateTrialListForm().ShowDialog();
        }

        private void subjectGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Researcher.Current.ActiveProject == null)
            {
                MessageBox.Show("Please create a project first.");
                return;
            }

            _listFormCreator.CreateSubjectGroupListForm().ShowDialog();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Researcher.Current.ActiveProject == null)
            {
                MessageBox.Show("Please create a project first.");
                return;
            }

            _listFormCreator.CreateSubjectListForm().ShowDialog();
        }

        private void bResearchers_Click(object sender, EventArgs e)
        {
            _listFormCreator.CreateResearcherListForm().ShowDialog();
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

        #region Projects menu

        private void FillProjectsMenu()
        {
            myProjectsToolStripMenuItem.DropDownItems.Clear();

            ToolStripMenuItem manageProjectsToolStripMenuItem = new ToolStripMenuItem();
            manageProjectsToolStripMenuItem.Text = "Manage Projects (Ctrl+P)";
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
            _listFormCreator.CreateProjectListForm().ShowDialog();

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

        private void DashBoard_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.T:
                    trialsToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.Control | Keys.S:
                    subjectsToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.Control | Keys.G:
                    subjectGroupsToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.Control | Keys.P:
                    manageProjectsToolStripMenuItem_Click(sender, e);
                    break;
            }
        }
    }
}
