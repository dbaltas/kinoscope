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

namespace observador
{
    public partial class ProjectForm : Form
    {
        private Project _project = null;

        public ProjectForm()
        {
            InitializeComponent();
        }

        public ProjectForm(Project project)
            : this()
        {
            if (project != null)
            {
                _project = project;
                txtName.Text = project.Name;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                Project project = _project ?? new Project();
                project.Name = txtName.Text;
                project.Tm = DateTime.Now;
                if (_project == null)
                {
                    Researcher.Current.AddProject(project);
                }
                Researcher.Current.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void bCreateFst_Click(object sender, EventArgs e)
        {
            SeedData.CreateDefaultFst(Researcher.Current, txtName.Text);
            this.Close();
        }
    }
}
