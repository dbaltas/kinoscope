using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib;
using ObLib.Domain;

namespace observador
{
    public class TrialListForm : ListForm<Trial>
    {
        public TrialListForm()
            : base(
            new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Session", HeaderText = "Session" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Duration", HeaderText = "Duration" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "CompleteRunCount", HeaderText = "Complete Runs" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "TmCreated", HeaderText = "Date Created" }},

                () => (IList)Researcher.Current.ActiveProject.Trials,

                (item) => new RunListForm(item))
        {
            ItemTypeDescription = "trial";
            Text = "Trials";
            Width = 900;
            _allowAdd = false;
            _allowRemove = false;
            _allowExport = true;
        }

        protected override void ItemExport(Trial trial)
        {
            ExportRun export = new ExportRun();
            export.exportTrial(trial);
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
    }
}
