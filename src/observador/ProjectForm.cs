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
    public partial class ProjectForm : ObWin.Form
    {
        private Project _project = null;

        public ProjectForm()
        {
            InitializeComponent();
            if (_project == null)
            {
                cbTemplate.DataSource = BehavioralTestType.All();
                bSave.Text = "Create Project";
            }
        }

        public ProjectForm(Project project)
            : this()
        {
            _project = project;
            if (_project != null)
            {
                txtName.Text = _project.Name;
                cbTemplate.Enabled = false;
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
                if (!ValidateChildren())
                {
                    ShowInputError();
                    return;
                }

                if (_project == null)
                {
                    Project project;
                    if (cbTemplate.SelectedItem == BehavioralTestType.Epm)
                    {
                        project = SeedData.CreateDefaultEpm(Researcher.Current, txtName.Text);
                    }
                    else if (cbTemplate.SelectedItem == BehavioralTestType.ObjectRecognition)
                    {
                        project = SeedData.CreateDefaultObjectRecognition(Researcher.Current, txtName.Text);
                    }
                    else
                    {
                        project = SeedData.CreateDefaultFst(Researcher.Current, txtName.Text);
                    }
                    if (CallerForm is ListForm<Project>)
                    {
                        (CallerForm as ListForm<Project>).OrderRefresh(project);
                    }
                }
                else
                {
                    _project.Name = txtName.Text;
                    _project.Save();
                }

                //dashboard.refreshprojectmenu

                this.Close();
            }
            catch (Exception ex)
            {
                FailWithError(ex);
            }
        }

        private void bCreateFst_Click(object sender, EventArgs e)
        {
            SeedData.CreateDefaultFst(Researcher.Current, txtName.Text);
            this.Close();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                e.Cancel = true;
                errorProvider.SetError(txtName, "Project name is required.");
            }
            else
            {
                errorProvider.SetError(txtName, "");
            }
        }
    }
}
