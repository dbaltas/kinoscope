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

        public DashBoard() : base()
        {
            InitializeComponent();
            ObWin.Form.SetMDIContainer(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void researchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listFormCreator.CreateResearcherListForm().Show();
        }

        private void trialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Researcher.Current.ActiveProject == null)
            {
                MessageBox.Show("Please create a project first.", "Cannot display trials");
                return;
            }

            (new TrialListForm()).Show();
        }

        private void subjectGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Researcher.Current.ActiveProject == null)
            {
                MessageBox.Show("Please create a project first.", "Cannot display subject groups");
                return;
            }

            _listFormCreator.CreateSubjectGroupListForm().Show();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Researcher.Current.ActiveProject == null)
            {
                MessageBox.Show("Please create a project first.", "Cannot display subjects");
                return;
            }

            _listFormCreator.CreateSubjectListForm().Show();
        }

        private void bResearchers_Click(object sender, EventArgs e)
        {
            _listFormCreator.CreateResearcherListForm().Show();
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
                NHibernateHelper.ProjectModified += new ProjectModifiedHandler(NHibernateHelper_ProjectModified);
                if (Researcher.Current.ActiveProject != null)
                {
                    NHibernateHelper.ActiveProjectModified += new ActiveProjectModifiedHandler(NHibernateHelper_ActiveProjectModified);
                }

                FillProjectsMenu();
                if (Researcher.Current.IsAdmin)
                {
                    adminToolStripMenuItem.Visible = true;
                }
                DisplayActiveProject();
            }
        }

        private void DisplayActiveProject()
        {
            Project activeProject = Researcher.Current.ActiveProject;

            // Set text in main window's Title Bar
            Text = string.Format(
                "{0} - {1}",
                activeProject == null ? "No project selected" : "Active Project: " + activeProject.Name,
                Program.GetTitle());
        }

        #region Projects menu

        private void FillProjectsMenu()
        {
            myProjectsToolStripMenuItem.DropDownItems.Clear();

            ToolStripMenuItem manageProjectsToolStripMenuItem = new ToolStripMenuItem();
            manageProjectsToolStripMenuItem.Text = "Manage Projects (Ctrl+P)";
            manageProjectsToolStripMenuItem.Click += manageProjectsToolStripMenuItem_Click;

            ToolStripMenuItem exportRunImagesToolStripMenuItem = new ToolStripMenuItem();
            exportRunImagesToolStripMenuItem.Text = "Export Run Images";
            exportRunImagesToolStripMenuItem.Click += exportRunImagesToolStripMenuItem_Click;


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
            myProjectsToolStripMenuItem.DropDownItems.Add(exportRunImagesToolStripMenuItem);
        }

        private void manageProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listFormCreator.CreateProjectListForm().Show();

            FillProjectsMenu();
            DisplayActiveProject();
        }

        private void exportRunImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Researcher.Current.ActiveProject == null)
            {
                MessageBox.Show("Please create a project first.", "Cannot extract run images");
                return;
            }

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;

                RunImageExporter runImageExporter = new RunImageExporter();
                runImageExporter.FolderPath = folderPath;
                int imagesExported = runImageExporter.Export(Researcher.Current.ActiveProject);

                MessageBox.Show(
                    string.Format(
                        "{1} images were exported in the following directory: {0}{2}",
                        Environment.NewLine, imagesExported, folderPath),
                    "Info");
            }
        }

        void projectItem_Click(object sender, EventArgs e)
        {
            Project selectedProject = (Project)((ToolStripMenuItem)sender).Tag;
            if (selectedProject != Researcher.Current.ActiveProject)
            {
                Researcher.Current.ActiveProject = selectedProject;
                NHibernateHelper.ActiveProjectModified +=new ActiveProjectModifiedHandler(NHibernateHelper_ActiveProjectModified);
                FillProjectsMenu();
                DisplayActiveProject();
            }
        }

        #endregion

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Control | Keys.T:
                    trialsToolStripMenuItem_Click(this, null);
                    break;
                case Keys.Control | Keys.S:
                    subjectsToolStripMenuItem_Click(this, null);
                    break;
                case Keys.Control | Keys.G:
                    subjectGroupsToolStripMenuItem_Click(this, null);
                    break;
                case Keys.Control | Keys.P:
                    manageProjectsToolStripMenuItem_Click(this, null);
                    break;
            }

            return false;
        }

        private void behaviorKeyStrokesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listFormCreator.CreateResearcherBehaviorKeyStrokeListForm().Show();
        }

        private void NHibernateHelper_ActiveProjectModified(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                f.Refresh();
            }
        }

        private void NHibernateHelper_ProjectModified(object sender, EventArgs e)
        {
            FillProjectsMenu();
            DisplayActiveProject();
        }

    }
}
