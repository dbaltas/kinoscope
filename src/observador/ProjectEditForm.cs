using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;
using ObLib;

namespace observador
{
    public partial class ProjectEditForm : ObWin.Form
    {
        private Project _project = null;

        public ProjectEditForm()
        {
            InitializeComponent();
            if (_project == null)
            {
            }
        }

        public ProjectEditForm(Project project)
            : this()
        {
            _project = project;
            if (_project != null)
            {
                for (int index = 0; index < _project.BehavioralTests.Count; index++)
                {
                    BehavioralTest behavioralTest = _project.BehavioralTests[index];
                    AddBehavioralTestControl(behavioralTest, index);
                }
            }

            int height = 140 + _project.BehavioralTests.Count * 70;
            this.Size = new System.Drawing.Size(400, height);
        }


        void AddBehavioralTestControl(BehavioralTest behavioralTest, int index)
        {
            ProjectBehavioralTestControl projectBehavioralTestControl1 = new ProjectBehavioralTestControl(_project, index, errorProvider);

            projectBehavioralTestControl1.TabIndex = 61;
            projectBehavioralTestControl1.Tag = behavioralTest;
            flowLayoutPanel1.Controls.Add(projectBehavioralTestControl1);
        }
    }
}
