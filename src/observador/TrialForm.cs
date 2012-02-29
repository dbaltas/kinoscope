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
    [Obsolete("Use ListForm<Run> instead.")]
    public partial class TrialForm : Form
    {
        Trial _trial;

        public TrialForm(Trial trial)
        {
            _trial = trial;
            InitializeComponent();
            DataGridViewColumn[] gridColumns = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Code", HeaderText = "subject" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Status", HeaderText = "status" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "DateRun", HeaderText = "dateRun" }};
            dgvMain.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in gridColumns)
            {
                column.ReadOnly = true;
            }

            dgvMain.Columns.AddRange(gridColumns);
            dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMain.MultiSelect = false;

            LoadForm();

            this.Text = String.Format("Trial:{0}, Session:{1}", _trial.Name, _trial.Session.ToString());
        }

        private void LoadForm()
        {
            BindingSource bindingSource = new BindingSource() { AllowNew = false };
            bindingSource.DataSource = _trial.Session.BehavioralTest.Project.Subjects;
            dgvMain.DataSource = bindingSource;

            int index = 0;
            foreach (Subject subject in _trial.Session.BehavioralTest.Project.Subjects)
            {
                string status = "not run";
                string strDateRun = "";
                Run run = subject.RunForTrial(_trial);
                if (run != null)
                {
                    status = "complete";
                    strDateRun = run.Tm.ToString();
                }
                dgvMain.Rows[index].Cells[1].Value = status;
                index++;
                dgvMain.Refresh();
            }
        }

        private void OrderEdit()
        {
            if (dgvMain.CurrentRow == null)
            {
                MessageBox.Show(string.Format("No {0} to edit.", "Run"));
                return;
            }

            Run run = new Run();
            run.Subject = (Subject)dgvMain.CurrentRow.DataBoundItem;
            _trial.AddRun(run);
            Form form = new RunForm((Run)run);
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                _trial.Runs.Remove(run);
            }
            LoadForm();
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderEdit();
        }

        private void dgvMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
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
                case Keys.Escape:
                    Close();
                    break;
            }
        }

    }
}
