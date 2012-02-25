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
    public partial class TrialListForm : ObWin.Form
    {
        public string ItemTypeDescription { get; set; }

        public TrialListForm()
        {
            InitializeComponent();

            dgvMain.AutoGenerateColumns = false;
            DataGridViewColumn[] columns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "id" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "name" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Session", HeaderText = "session" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "BehavioralTest", HeaderText = "test" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Tm", HeaderText = "Date Created" }};

            foreach (DataGridViewColumn column in columns)
            {
                column.ReadOnly = true;
            }

            dgvMain.Columns.AddRange(columns);
            LoadForm();
        }

        private void LoadForm()
        {
            BindingSource bindingSource = new BindingSource() { AllowNew = false };
            bindingSource.DataSource = Researcher.Current.ActiveProject.BehavioralTests[0].Sessions[0].Trials;
            dgvMain.DataSource = bindingSource;
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
