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
    public class BehavioralTestTemplateListForm : ListForm<EntityTemplate>
    {
        public BehavioralTestTemplateListForm()
            : base(
            new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" },
                new DataGridViewTextBoxColumn() { DataPropertyName = "TmCreated", HeaderText = "Date Created" }},

                () => (IList)EntityTemplate.All(),

                (item) => new BehavioralTestTemplateForm(item))
        {
            ItemTypeDescription = "template";
            Text = "Behavioral Test Templates";
            Width = 900;
        }
    }
}
