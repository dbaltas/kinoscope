using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib;
using ObLib.Domain;

namespace kinoscope
{
    public class ResearcherBehaviorKeyStrokeListForm : ListForm<ResearcherBehaviorKeyStroke>
    {
        public ResearcherBehaviorKeyStrokeListForm()
            : base(
            new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "BehavioralTestType", HeaderText = "Behavioral Test Type" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Behavior", HeaderText = "Behavior" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "KeyStroke", HeaderText = "Key Stroke" }},

                () => ResearcherBehaviorKeyStroke.AllForListForm(),
                (item) => new ResearcherBehaviorKeyStrokeForm(item))
                {
                    ItemTypeDescription = "key stroke";
                    Text = "Behavior Key Strokes";
                    _allowAdd = false;   
                }
    }
}
