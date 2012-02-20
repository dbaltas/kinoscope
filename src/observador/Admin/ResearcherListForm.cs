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
    public partial class AdminResearcherListForm : Form
    {
        public AdminResearcherListForm()
        {
            InitializeComponent();
            dgvResearchers.AutoGenerateColumns = false;
        }

        private void LoadForm()
        {
            BindingSource bindingSource = new BindingSource() { AllowNew = false };
            bindingSource.DataSource = Researcher.All();
            dgvResearchers.DataSource = bindingSource;
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
            AdminResearcherForm form = new AdminResearcherForm();
            form.ShowDialog();
            LoadForm();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dgvResearchers.CurrentRow == null)
            {
                MessageBox.Show("No user to edit.");
                return;
            }

            AdminResearcherForm form = new AdminResearcherForm((Researcher)dgvResearchers.CurrentRow.DataBoundItem);
            form.ShowDialog();
            LoadForm();
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            if (dgvResearchers.CurrentRow == null)
            {
                MessageBox.Show("No user to delete.");
                return;
            }

            Researcher researcherToDelete = (Researcher)dgvResearchers.CurrentRow.DataBoundItem;

            String deleteMsg = String.Format("Are you sure you want to delete user {0}?", researcherToDelete.Username);
            DialogResult dialogResult = MessageBox.Show(deleteMsg, "Delete Researcher", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No) {
                return;
            }

            researcherToDelete.Delete();
            LoadForm();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
