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
            InitializeComponent();
            _ErrorProvider = errorProvider;
            cmbTrialCount.SelectedIndex = 0;
            _Session = behavioralTest.Sessions[sessionIndex];
            txtDuration.Text = _Session.Trials[0].Duration.ToString();
            groupBox1.Text = String.Format("Session: {0}", _Session.Name);
            txtName.Text = _Session.Name;
            txtName.Enabled = (behavioralTest.Sessions.Count == 1) ? false : true;
        }

        private void txtDuration_Validating(object sender, CancelEventArgs e)
        {
            Control control = (Control)sender;
            ErrorProvider errorProvider = _ErrorProvider;
            string text = control.Text;

            int result;
            if (!Int32.TryParse(text, out result))
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Please provide a valid number for duration.");
                return;
            }
            if (result <= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Please provide a positive number for duration.");
                return;
            }

            errorProvider.SetError(control, "");
        }

        public void Save()
        {
            _Session.Trials[0].Duration = Int32.Parse(txtDuration.Text);
            _Session.Name = txtName.Text;
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
    }
}
