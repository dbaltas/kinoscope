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
        }

        private void LoadForm()
        {
            var researchers = Researcher.All();
            DataGridViewRow row = new DataGridViewRow();

            dgvResearchers.Rows.Clear();

            foreach (Researcher researcher in researchers)
            {
                string[] row1 = new string[] { researcher.Id.ToString(), 
                    researcher.Username, researcher.Projects.Count().ToString() };
                dgvResearchers.Rows.Add(row1);
            }
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
            form.Show();
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            DataGridViewRow rowToDelete = dgvResearchers.CurrentRow;

            String deleteMsg = String.Format("Are you sure you want to delete user {0}?", rowToDelete.Cells["username"].Value.ToString());
            DialogResult dialogResult = MessageBox.Show(deleteMsg, "Delete Researcher", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No) {
                return;
            }
            MessageBox.Show("method not implemented");
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
