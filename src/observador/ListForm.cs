using System;
using System.Collections;
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
    public partial class ListForm<T> : ObWin.Form where T : ActiveRecordBase<T>
    {
        public delegate IList DataSourceDelegate();
        public delegate Form CreateDetailFormDelegate(T item);

        private DataSourceDelegate _createDataSource;
        private CreateDetailFormDelegate _createDetailForm;
        public string ItemTypeDescription { get; set; }

        public ListForm(
            DataGridViewColumn[] gridColumns,
            DataSourceDelegate createDataSource,
            CreateDetailFormDelegate createDetailForm
            )
        {
            ItemTypeDescription = "item";

            InitializeComponent();

            dgvMain.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in gridColumns)
            {
                column.ReadOnly = true;
            }

            dgvMain.Columns.AddRange(gridColumns);

            _createDataSource = createDataSource;
            _createDetailForm = createDetailForm;
        }

        private void LoadForm()
        {
            BindingSource bindingSource = new BindingSource() { AllowNew = false };
            bindingSource.DataSource = _createDataSource();
            dgvMain.DataSource = bindingSource;
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            Form form = _createDetailForm(null);
            form.ShowDialog();
            LoadForm();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow == null)
            {
                MessageBox.Show(string.Format("No {0} to edit.", ItemTypeDescription));
                return;
            }

            Form form = _createDetailForm((T)dgvMain.CurrentRow.DataBoundItem);
            form.ShowDialog();
            LoadForm();
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow == null)
            {
                MessageBox.Show(string.Format("No {0} to delete.", ItemTypeDescription));
                return;
            }

            T itemToDelete = (T)dgvMain.CurrentRow.DataBoundItem;

            String deleteMsg = String.Format("Are you sure you want to delete {0} {1}?",
                                             ItemTypeDescription, itemToDelete);
            DialogResult dialogResult = MessageBox.Show(deleteMsg,
                                                        string.Format("Delete {0}", ItemTypeDescription),
                                                        MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            itemToDelete.Delete();

            LoadForm();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
