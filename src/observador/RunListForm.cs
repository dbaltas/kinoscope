using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace observador
{
    public class RunListForm : ListForm<Run>
    {
        public RunListForm(Trial trial)
            : base(
            new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Subject", HeaderText = "Subject" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "StatusDescription", HeaderText = "Status" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "TmRun", HeaderText = "Date Run" }},

                () => { trial.PopulateWithRuns(); return (IList)trial.Runs; },

                (item) => item.Status == Run.RunStatus.NotRun
                    ? (ObWin.Form)new RunForm(item)
                    : (ObWin.Form)new RunEventListForm(item))
        {
            ItemTypeDescription = "run";
            Text = string.Format("Trial: {0}, Session: {1}", trial, trial.Session);
            Width = 600;
            _allowAdd = false;
            _allowExport = true;
            _allowRun = true;
        }

        protected override void ItemExport(DataGridViewRow dgvRow)
        {
            Run run = (Run)dgvRow.DataBoundItem;
            if (run.Status == Run.RunStatus.NotRun)
            {
                MessageBox.Show("Run Is not complete. Click 'Run' to complete");
                return;
            }
            run.Export();
            MessageBox.Show("Export Successful at application directory.");
        }

        protected override void ItemRun(DataGridViewRow dgvRow)
        {
            Run run = (Run)dgvRow.DataBoundItem;
            if (run.Status == Run.RunStatus.Complete)
            {
                MessageBox.Show("Run Is already complete. Delete first if you want to run again");
                return;
            }
            (new RunForm(run)).ShowDialog();
        }
    }
}
