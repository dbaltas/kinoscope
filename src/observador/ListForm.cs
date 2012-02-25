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
            CreateDetailFormDelegate createDetailForm, 
            bool ShowToolStrip = true
            )
        {
            ItemTypeDescription = "item";

            InitializeComponent();

            if (!ShowToolStrip)
            {
                toolStrip1.Hide();
            }

            dgvMain.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in gridColumns)
            {
                column.ReadOnly = true;
            }

            dgvMain.Columns.AddRange(gridColumns);
            dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMain.MultiSelect = false;

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

        #region Toolstrip buttons

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            OrderNew();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            OrderEdit();
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            OrderRemove();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            OrderRefresh();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            OrderClose();
        }

        #endregion

        #region Order implementations

        private void OrderNew()
        {
            Form form = _createDetailForm(null);
            form.ShowDialog();
            LoadForm();
        }

        private void OrderEdit()
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

        private void OrderRemove()
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

        private void OrderRefresh()
        {
            LoadForm();
        }

        private void OrderClose()
        {
            Close();
        }

        #endregion

        private void ListForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        OrderNew();
                    }
                    break;
                case Keys.Insert:
                    OrderNew();
                    break;
                case Keys.E:
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        OrderEdit();
                    }
                    break;
                case Keys.F2:
                case Keys.Enter:
                    OrderEdit();
                    break;
                case Keys.Delete:
                    OrderRemove();
                    break;
                case Keys.F5:
                    OrderRefresh();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderEdit();
        }
    }
}
