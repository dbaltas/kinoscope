using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib;
using ObLib.Domain;
using ObLib.Export;

namespace kinoscope
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

        protected override void ItemExport(Run run)
        {
            if (run.Status == Run.RunStatus.NotRun)
            {
                MessageBox.Show("Run Is not complete. Click 'Run' to complete", "Cannot export");
                return;
            }

            Run.ValidationResult runValidationResult = run.Validate();
            if (!runValidationResult.IsValid)
            {
                MessageBox.Show(
                    string.Format(
                        "Run data not valid. Please correct them and try again. {0}{0}Details: {0}{1}",
                        Environment.NewLine,
                        runValidationResult.Error),
                    "Cannot export");
                return;
            }

            ExportRun export = new ExportRun();
            export.exportRun(run);

            string folderPath = String.Format(String.Format("{0}/{1}/text/",
            ExportRun.EXPORT_DIRECTORY,
            ExportRun.ToFriendlyFilename(Researcher.Current.ActiveProject.ToString())));

            DialogResult dialogResult = MessageBox.Show(
                string.Format(
                    "Export Successfull in the following directory: {0}\n\nOpen Containing Folder?",
                    System.IO.Path.GetFullPath(folderPath)),
                "Exported Trial", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(System.IO.Path.GetFullPath(folderPath));
            }

        }

        protected override void ItemRun(Run run)
        {
            if (run.Status == Run.RunStatus.Complete)
            {
                MessageBox.Show("Run Is already complete. Delete first if you want to run again", "Cannot run");
                return;
            }
            (new RunForm(run)).Show();
        }
    }
}
