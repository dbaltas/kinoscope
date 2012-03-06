using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace observador
{
    public class RunEventListForm : ListForm<RunEvent>
    {
        public RunEventListForm(Run run)
            : base(
                new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Behavior", HeaderText = "Behavior" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "TimeTracked", HeaderText = "Time Tracked (ms)" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Tm", HeaderText = "Date Modified" }},

                () => (IList)run.RunEvents.OrderBy((item) => item.TimeTracked).ToList(),

                (item) => item == null ? new RunEventForm(run) : new RunEventForm(item))
        {
            ItemTypeDescription = "run event";
            Text = "Run Events";
            Width = 600;
        }
    }
}
