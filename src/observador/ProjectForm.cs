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
        }

        public ProjectForm(Project project)
            : this()
        {
            if (project != null)
            {
                _project = project;
                txtName.Text = project.Name;
            }
            else
            {
                bSave.Text = "Create FST Project";
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
                    Project project = SeedData.CreateDefaultFst(Researcher.Current, txtName.Text);
                    if (Owner is ListForm<Project>)
                    {
                        (Owner as ListForm<Project>).OrderRefresh(project);
                    }
                    this.Close();
                }
                else
                {
                    _project.Name = txtName.Text;
                    _project.Save();
                }

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
