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
    public partial class SubjectGroupForm : ObWin.Form
    {
        private SubjectGroup _subjectGroup = null;

        public SubjectGroupForm()
        {
            InitializeComponent();
        }

        public SubjectGroupForm(SubjectGroup subjectGroup)
            : this()
        {
            if (subjectGroup != null)
            {
                _subjectGroup = subjectGroup;
                txtName.Text = subjectGroup.Name;
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

                SubjectGroup subjectGroup = _subjectGroup ?? new SubjectGroup();

                subjectGroup.Name = txtName.Text;
                if (_subjectGroup == null)
                {
                    Researcher.Current.ActiveProject.AddSubjectGroup(subjectGroup);
                    Researcher.Current.ActiveProject.Save();
                }
                else
                {
                    _subjectGroup.Save();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                FailWithError(ex);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                e.Cancel = true;
                errorProvider.SetError(txtName, "Subject group name is required.");
            }
            else
            {
                errorProvider.SetError(txtName, "");
            }
        }
    }
}
