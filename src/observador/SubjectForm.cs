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
    public partial class SubjectForm : Form
    {
        private Subject _subject = null;

        public SubjectForm()
        {
            InitializeComponent();
            cbSubjectGroup.DataSource = Researcher.Current.ActiveProject.SubjectGroups;
        }

        public SubjectForm(Subject subject) : this()
        {
            cbSex.SelectedIndex = 0;

            if (subject != null)
            {
                _subject = subject;
                txtCode.Text = subject.Code;
                cbSubjectGroup.SelectedItem = subject.SubjectGroup;
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
            Subject subject = _subject ?? new Subject();

            subject.Code = txtCode.Text;
            subject.SubjectGroup = (SubjectGroup)cbSubjectGroup.SelectedItem;
            subject.Strain = txtStrain.Text;
            subject.Sex = cbSex.SelectedItem.ToString();
            subject.DateOfBirth = dtDob.Value;
            subject.Origin = txtOrigin.Text;
            subject.Weight = Decimal.Parse(txtWeight.Text);
            subject.Tm = DateTime.Now;
            if (_subject == null)
            {
                Researcher.Current.ActiveProject.AddSubject(subject);
            }
            subject.Project.Save();
            this.Close();
        }
    }
}
