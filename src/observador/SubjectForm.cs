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
    public partial class SubjectForm : ObWin.Form
    {
        private Subject _subject = null;

        public SubjectForm()
        {
            InitializeComponent();
            List<SubjectGroup> comboBoxSubjectGroups = new List<SubjectGroup>();

            SubjectGroup emptySubjectGroup = new SubjectGroup();
            emptySubjectGroup.Id = -1;
            emptySubjectGroup.Name = "<None>";

            comboBoxSubjectGroups.Add(emptySubjectGroup);
            comboBoxSubjectGroups.AddRange(Researcher.Current.ActiveProject.SubjectGroups);

            cbSubjectGroup.DataSource = comboBoxSubjectGroups;
        }

        public SubjectForm(Subject subject)
            : this()
        {
            cbSex.SelectedIndex = 0;

            if (subject != null)
            {
                _subject = subject;
                txtCode.Text = subject.Code;

                cbSubjectGroup.SelectedItem = subject.SubjectGroup ?? cbSubjectGroup.Items[0];

                txtStrain.Text = subject.Strain;
                cbSex.SelectedItem = subject.Sex;
                dtDob.Value = subject.DateOfBirth;
                txtOrigin.Text = subject.Origin;
                txtWeight.Text = subject.Weight.ToString();
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

                Subject subject = _subject ?? new Subject();

                subject.Code = txtCode.Text;
                subject.Strain = txtStrain.Text;
                subject.Sex = cbSex.SelectedItem.ToString();
                subject.DateOfBirth = dtDob.Value;
                subject.Origin = txtOrigin.Text;
                subject.Weight = txtWeight.Text == "" ? (Decimal?)null : Decimal.Parse(txtWeight.Text);

                subject.SubjectGroup = (SubjectGroup)cbSubjectGroup.SelectedItem;
                if (subject.SubjectGroup.Id == -1)
                {
                    subject.SubjectGroup = null;
                }
                else
                {
                    subject.SubjectGroup.AddSubject(subject);
                }

                if (_subject == null)
                {
                    Researcher.Current.ActiveProject.AddSubject(subject);
                }
                subject.Project.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void txtWeight_Validating(object sender, CancelEventArgs e)
        {
            Decimal weight;
            if (txtWeight.Text != ""
                && (!Decimal.TryParse(txtWeight.Text, out weight)
                    || weight < 0
                    // The following condition is to prevent parser sweeping-off separators
                    // e.g. in greek locale 3,5 is parsed correctly as three and a half
                    // but 3.5 is parsed as thirty five.
                    || weight.ToString() != txtWeight.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtWeight, "Invalid weight. Must be a non-negative number.");
            }
            else
            {
                errorProvider.SetError(txtWeight, "");
            }
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCode.Text == "")
            {
                e.Cancel = true;
                errorProvider.SetError(txtCode, "Subject code is required.");
            }
            else
            {
                errorProvider.SetError(txtCode, "");
            }
        }
    }
}
