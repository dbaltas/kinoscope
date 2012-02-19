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
    public partial class ProjectListForm : Form
    {
        public ProjectListForm()
        {
            InitializeComponent();
            dgvProjects.AutoGenerateColumns = false;
        }

        private void LoadForm()
        {
            dgvProjects.DataSource = Researcher.Current().Projects;
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
            ProjectForm form = new ProjectForm();
            form.ShowDialog();
            LoadForm();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ProjectForm form = new ProjectForm((Project)dgvProjects.CurrentRow.DataBoundItem);
            form.ShowDialog();
            LoadForm();
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            Project projectToDelete = (Project)dgvProjects.CurrentRow.DataBoundItem;

            String deleteMsg = String.Format("Are you sure you want to delete project {0}?", projectToDelete.Name);
            DialogResult dialogResult = MessageBox.Show(deleteMsg, "Delete Project", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No) {
                return;
            }

            projectToDelete.Delete();
            LoadForm();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
