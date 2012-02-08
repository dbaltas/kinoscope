using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;
using ObLib.Repositories;

namespace observador
{
    public partial class AdminResearchers : Form
    {
        public AdminResearchers()
        {
            InitializeComponent();
            dgvResearchers.AutoGenerateColumns = false;
        }

        private void LoadForm()
        {
            dgvResearchers.DataSource = Researcher.All();
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
            AdminResearcher form = new AdminResearcher();
            form.ShowDialog();
            LoadForm();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            AdminResearcher form = new AdminResearcher((Researcher)dgvResearchers.CurrentRow.DataBoundItem);
            form.ShowDialog();
            LoadForm();
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
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
