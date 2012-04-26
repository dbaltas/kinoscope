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
    public partial class BehavioralTestTemplateSessionControl : UserControl
    {
        private ErrorProvider _ErrorProvider;
        private Session _Session;

        public BehavioralTestTemplateSessionControl(BehavioralTest behavioralTest, int sessionIndex, ErrorProvider errorProvider)
        {
            _Session = behavioralTest.Sessions[sessionIndex];

            InitializeComponent();
            _ErrorProvider = errorProvider;
            cmbTrialCount.SelectedIndex = _Session.Trials.Count;

            groupBox1.Text = String.Format("Session: {0}", _Session.Name);
            txtName.Text = _Session.Name;
            txtName.Enabled = (behavioralTest.Sessions.Count == 1) ? false : true;

            RemoveTrialControls();
            for (int index = 0; index < _Session.Trials.Count; index++)
            {
                Trial trial = _Session.Trials[index];
                AddTrialControl(trial, index);
            }
        }

        public void Save()
        {
            _Session.Name = txtName.Text;

            for (int ix = flowLayoutPanel1.Controls.Count - 1; ix >= 0; ix--)
            {
                Control c = flowLayoutPanel1.Controls[ix];
                if (c is BehavioralTestTemplateTrialControl)
                {
                    BehavioralTestTemplateTrialControl bc = (BehavioralTestTemplateTrialControl)c;
                    bc.Save();
                }
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Control control = (Control)sender;
            ErrorProvider errorProvider = _ErrorProvider;
            string text = control.Text;

            if (text.Length == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Name can not be empty.");
                return;
            }

            errorProvider.SetError(control, "");
        }

        void AddTrialControl(Trial trial, int index)
        {
            BehavioralTestTemplateTrialControl trial1 = new BehavioralTestTemplateTrialControl(_Session, index, _ErrorProvider);

            trial1.Size = new System.Drawing.Size(274, 55);
            trial1.TabIndex = 61;
            trial1.Tag = trial;
            flowLayoutPanel1.Controls.Add(trial1);
        }

        void RemoveTrialControls()
        {
            for (int ix = flowLayoutPanel1.Controls.Count - 1; ix >= 0; ix--)
            {
                Control c = flowLayoutPanel1.Controls[ix];
                if (c is BehavioralTestTemplateTrialControl)
                {
                    c.Dispose();
                }
            }
        }


        private void cmbTrialCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox control = (ComboBox)sender;
            int trialCount = Int32.Parse(control.SelectedItem.ToString());

            RemoveTrialControls();
            if (trialCount == 0)
            {
                return;
            }

            List<Trial> lastTrials = new List<Trial>();
            lastTrials.AddRange(_Session.Trials);

            _Session.Trials.Clear();
            _Session.TrialsForSerialization.Clear();

            for (int i = 0; i < trialCount; i++)
            {
                Trial trial = new Trial();
                if (lastTrials.Count >= i + 1)
                {
                    trial = lastTrials[i];
                }
                else
                {
                    trial.Name = String.Format("T{0}", i + 1);
                }
                _Session.Trials.Add(trial);
            }
            for (int i = 0; i < trialCount; i++)
            {
                AddTrialControl(_Session.Trials[i], i);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Text = String.Format("Session: {0}", txtName.Text);
        }
    }
}
