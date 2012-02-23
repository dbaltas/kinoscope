using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace observador
{
    [Obsolete("Use ListForm<SubjectGroup> instead.")]
    public partial class SubjectGroupListForm : Form
    {
        public SubjectGroupListForm()
        {
            InitializeComponent();
            dgvSubjectGroups.AutoGenerateColumns = false;
        }

        private void LoadForm()
        {
            BindingSource bindingSource = new BindingSource() { AllowNew = false };
            bindingSource.DataSource = Researcher.Current.ActiveProject.SubjectGroups;
            dgvSubjectGroups.DataSource = bindingSource;
        }

        private void AdminResearchers_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            SubjectGroupForm form = new SubjectGroupForm();
            form.ShowDialog();
            LoadForm();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dgvSubjectGroups.CurrentRow == null)
            {
                MessageBox.Show("No subject group to edit.");
                return;
            }

            SubjectGroupForm form = new SubjectGroupForm((SubjectGroup)dgvSubjectGroups.CurrentRow.DataBoundItem);
            form.ShowDialog();
            LoadForm();
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            if (dgvSubjectGroups.CurrentRow == null)
            {
                MessageBox.Show("No subject group to delete.");
                return;
            }

            SubjectGroup subjectGroupToDelete = (SubjectGroup)dgvSubjectGroups.CurrentRow.DataBoundItem;

            String deleteMsg = String.Format("Are you sure you want to delete subject group {0}?", subjectGroupToDelete.Name);
            DialogResult dialogResult = MessageBox.Show(deleteMsg, "Delete Subject Group", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            Researcher.Current.ActiveProject.SubjectGroups.Remove(subjectGroupToDelete);
            Researcher.Current.ActiveProject.Save();

            LoadForm();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
