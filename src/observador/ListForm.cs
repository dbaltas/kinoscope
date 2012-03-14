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

        protected bool _allowAdd = true;
        protected bool _allowEdit = true;
        protected bool _allowRemove = true;
        protected bool _allowRun = false;
        protected bool _allowExport = false;

        private DataSourceDelegate _createDataSource;
        private CreateDetailFormDelegate _createDetailForm;
        public string ItemTypeDescription { get; set; }

        public ListForm(
            DataGridViewColumn[] gridColumns,
            DataSourceDelegate createDataSource,
            CreateDetailFormDelegate createDetailForm)
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

            RefreshToolbar();
        }

        protected void RefreshToolbar()
        {
            toolStripButtonAdd.Visible = _allowAdd;
            toolStripButtonEdit.Visible = _allowEdit;
            toolStripButtonRemove.Visible = _allowRemove;
            toolStripButtonRun.Visible = _allowRun;
            toolStripButtonExport.Visible = _allowExport;
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
            try
            {
                if (!_allowAdd)
                {
                    return;
                }

                Form form = _createDetailForm(null);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                FailWithError(ex);
            }

            LoadForm();
        }

        private void OrderEdit()
        {
            try
            {
                if (!_allowEdit)
                {
                    return;
                }

                if (dgvMain.CurrentRow == null)
                {
                    MessageBox.Show(string.Format("No {0} to edit.", ItemTypeDescription));
                    return;
                }

                Form form = _createDetailForm((T)dgvMain.CurrentRow.DataBoundItem);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                FailWithError(ex);
            }

            LoadForm();
        }

        private void OrderRemove()
        {
            try
            {
                if (!_allowRemove)
                {
                    return;
                }

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
            }
            catch (Exception ex)
            {
                FailWithError(ex);
            }

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
            switch (e.KeyData)
            {
                case Keys.Control | Keys.N:
                case Keys.Insert:
                    OrderNew();
                    break;
                case Keys.Control | Keys.E:
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
