using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }
    }
}
