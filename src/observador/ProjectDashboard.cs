using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObWin;
using ObLib.Domain;

namespace observador
{
    public partial class ProjectDashboard : ObWin.Form
    {
        public ProjectDashboard()
        {
            InitializeComponent();
            NHibernateHelper.ActiveProjectChanged += new ActiveProjectChangedHandler(NHibernateHelper_ActiveProjectChanged);
        }

        private void ProjectDashboard_Load(object sender, EventArgs e)
        {
            LoadForm(Researcher.Current.ActiveProject);
        }

        private void LoadForm(Project project)
        {
            for (int ix = panel1.Controls.Count - 1; ix >= 0; ix--)
            {
                Control control = panel1.Controls[ix];
                if (control is Button && control.Tag != null)
                {
                    control.Dispose();
                }
            }

            if (project == null)
            {
                lblProjectName.Text = "No Projects Founds";
                btnAddProject.Visible = true;
                return;
            }

            lblProjectName.Text = String.Format("Project: {0}", project);
            int x = 40;
            int tabIndex = 2;
            Button button;
            foreach (BehavioralTest test in project.BehavioralTests)
            {
                button = new Button();
                button.Location = new Point(x, 80);
                button.Size = new System.Drawing.Size(200, 80);
                button.TabIndex = tabIndex;
                button.Text = test.Name + ' ' + test.BehavioralTestType.ToString() + " p:" + test.Project.ToString();
                button.Tag = test;
                button.Click += new System.EventHandler(this.btnBehavioralTest_Click);
                panel1.Controls.Add(button);

                x += 250;
                tabIndex++;
            }


            button = new Button();
            button.Location = new Point(40, 180);
            button.Size = new System.Drawing.Size(200, 60);
            button.TabIndex = tabIndex;
            button.Text = "add new subject";
            button.Click += new System.EventHandler(this.btnAddSubject_Click);
            panel1.Controls.Add(button);

            button = new Button();
            button.Location = new Point(290, 180);
            button.Size = new System.Drawing.Size(200, 60);
            button.TabIndex = tabIndex;
            button.Click += new System.EventHandler(this.btnAddBehavioralTest_Click);
            button.Text = "add new behavioral test";
            panel1.Controls.Add(button);

        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            ProjectForm form = new ProjectForm();
            form.Show();
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            SubjectForm form = new SubjectForm();
            form.Show();
        }


        private void btnAddBehavioralTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Method not implemented");
        }

        private void btnBehavioralTest_Click(object sender, EventArgs e)
        {
            BehavioralTest test = (BehavioralTest)(((Button)sender).Tag);
            RunListForm runListForm = new RunListForm(test.Sessions[0].Trials[0]);
            runListForm.Show();
        }

        public void NHibernateHelper_ActiveProjectChanged(object sender, EventArgs e)
        {
            LoadForm((Project)(sender));
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProjectDashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
