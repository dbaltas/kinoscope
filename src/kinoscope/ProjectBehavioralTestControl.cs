using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace kinoscope
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
            string msg = String.Format("Are you sure you want to delete {1} from project {0}?",
                _BehavioralTest.Project, _BehavioralTest);
            List<Run> testRuns = _BehavioralTest.GetRuns();
            if (testRuns.Count > 0)
            {
                string runsMsg = testRuns.Count == 1 ? "1 Run" : String.Format("All {0} Runs", testRuns.Count);
                msg = String.Format("{0}\nNote: {1} in this behavioral test will be deleted.", 
                    msg, runsMsg);
            }
            if (MessageBox.Show(msg, "Delete Behavioral Test", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) 
            {
                this.Dispose();
                _BehavioralTest.Project.BehavioralTests.Remove(_BehavioralTest);
                _BehavioralTest.Project.Save();
            }
        }
    }
}
