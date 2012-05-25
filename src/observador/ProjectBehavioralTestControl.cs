using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace observador
{
    public partial class ProjectBehavioralTestControl : UserControl
    {
        private ErrorProvider _ErrorProvider;
        private BehavioralTest _BehavioralTest;

        public ProjectBehavioralTestControl(Project project, int behavioralTestIndex, ErrorProvider errorProvider)
        {
            _BehavioralTest = project.BehavioralTests[behavioralTestIndex];
            InitializeComponent();
            _ErrorProvider = errorProvider;
            lblBehavioralTest.Text = project.BehavioralTests[behavioralTestIndex].Name;
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            _BehavioralTest.Project.BehavioralTests.Remove(_BehavioralTest);
            this.Parent.Refresh();
        }
    }
}
