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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Researcher.Current = null;
            tssResearcher.Text = "";
            SetTitle();
            DashBoard_Load(this, null);
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
            if (!RequireActiveProject() || !RequireSubjects())
            {
                return;
            }

            (new TrialListForm()).Show();
        }

        private void subjectGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RequireActiveProject())
            {
                return;
            }

            _listFormCreator.CreateSubjectGroupListForm().Show();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RequireActiveProject())
            {
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
                return;
            }

            Project activeProject = Researcher.Current.ActiveProject;
            SetTitle();
            tssResearcher.Text = String.Format("Researcher {0} logged in", Researcher.Current.Username);
            activeProjectToolStripMenuItem.Text = activeProject != null ? activeProject.ToString() : "(Project)";

            NHibernateHelper.ProjectModified += new ProjectModifiedHandler(NHibernateHelper_ProjectModified);
            NHibernateHelper.ActiveProjectChanged += new ActiveProjectChangedHandler(NHibernateHelper_ActiveProjectChanged);
            if (activeProject != null)
            {
                NHibernateHelper.ActiveProjectModified += new ActiveProjectModifiedHandler(NHibernateHelper_ActiveProjectModified);
            }

            FillProjectsMenu();
            if (Researcher.Current.IsAdmin)
            {
                templatesToolStripMenuItem.Visible = true;
                researchersToolStripMenuItem.Visible = true;
//                    templatesToolStripMenuItem_Click(null, null);
            }
            else
            {
                templatesToolStripMenuItem.Visible = false;
                researchersToolStripMenuItem.Visible = false;
                //                    scoreToolStripMenuItem_Click(null, null);
            }
        }

        private void SetTitle()
        {
            Project activeProject = Researcher.Current != null ? Researcher.Current.ActiveProject : null;

            // Set text in main window's Title Bar
            Text = string.Format(
                "{0} - {1}",
                activeProject == null ? "No project selected" : "Active Project: " + activeProject.Name,
                Program.GetTitle());
        }

        #region Projects menu

        private void FillProjectsMenu()
        {
            setActiveProjectToolStripMenuItem.DropDownItems.Clear();

            foreach (Project project in Researcher.Current.Projects)
            {
                ToolStripMenuItem projectToolStripMenuItem = new ToolStripMenuItem(project.Name);
                projectToolStripMenuItem.Checked = project == Researcher.Current.ActiveProject;
                projectToolStripMenuItem.Click += projectItem_Click;
                projectToolStripMenuItem.Tag = project;
                setActiveProjectToolStripMenuItem.DropDownItems.Add(projectToolStripMenuItem);
            }

            if (Researcher.Current.Projects.Count == 0)
            {
                ToolStripMenuItem noProjectToolStripMenuItem = new ToolStripMenuItem("no projects found");
                noProjectToolStripMenuItem.Enabled = false;
                setActiveProjectToolStripMenuItem.DropDownItems.Add(noProjectToolStripMenuItem);
            }
        }

        private void manageProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ProjectListForm()).Show();

            FillProjectsMenu();
            SetTitle();
        }

        private void exportRunImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RequireActiveProject() || !RequireSubjects())
            {
                return;
            }

                string folderPath = String.Format(String.Format("{0}/{1}/images/",
                ExportRun.EXPORT_DIRECTORY,
                ExportRun.ToFriendlyFilename(Researcher.Current.ActiveProject.ToString())));

                RunImageExporter runImageExporter = new RunImageExporter();
                runImageExporter.FolderPath = folderPath;
                int imagesExported = runImageExporter.Export(Researcher.Current.ActiveProject);

                DialogResult dialogResult = MessageBox.Show(
                    string.Format(
                        "{1} images were exported in the following directory: {0}{2}\n\nOpen Containing Folder?",
                        Environment.NewLine, imagesExported, System.IO.Path.GetFullPath(folderPath)),
                    "Images Exported", MessageBoxButtons.YesNo);

                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(System.IO.Path.GetFullPath(folderPath));
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
                SetTitle();
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
                case Keys.Control | Keys.R:
                    scoreToolStripMenuItem_Click(this, null);
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
            (new ResearcherBehaviorKeyStrokeListForm()).Show();
        }

        private void NHibernateHelper_ActiveProjectModified(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                f.Refresh();
            }
        }

        void NHibernateHelper_ActiveProjectChanged(object sender, EventArgs e)
        {
            activeProjectToolStripMenuItem.Text = Researcher.Current.ActiveProject != null ? Researcher.Current.ActiveProject.ToString() : "(Project)";
            foreach (Form f in MdiChildren)
            {
                f.Refresh();
            }
        }

        private void NHibernateHelper_ProjectModified(object sender, EventArgs e)
        {
            FillProjectsMenu();
            SetTitle();
            activeProjectToolStripMenuItem.Text = Researcher.Current.ActiveProject != null ? Researcher.Current.ActiveProject.ToString() : "(Project)";
        }

        private void templatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new BehavioralTestTemplateListForm()).Show();
        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RequireActiveProject() || !RequireSubjects())
            {
                return;
            }

            (new RunForm()).Show();
        }

        private bool RequireActiveProject()
        {
            if (Researcher.Current.ActiveProject == null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you wish to create a project now?", "No Project found", MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    (new ProjectForm()).Show();
                }
                return false;
            }
            return true;
        }

        private bool RequireSubjects()
        {
            if (Researcher.Current.ActiveProject.Subjects.Count == 0)
            {
                DialogResult dialogResult = MessageBox.Show("The project does not have any subjects.\nDo you wish to create a subject now?", "No Subjects found", MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    (new SubjectForm()).Show();
                }
                return false;
            }
            return true;
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String path = "../doc";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            System.Diagnostics.Process.Start(System.IO.Path.GetFullPath(path));
        }
    }
}
