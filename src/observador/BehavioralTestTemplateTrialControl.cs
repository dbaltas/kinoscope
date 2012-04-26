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
    public partial class BehavioralTestTemplateTrialControl : UserControl
    {
        private ErrorProvider _ErrorProvider;
        private Trial _Trial;

        public BehavioralTestTemplateTrialControl(Session session, int trialIndex, ErrorProvider errorProvider)
        {
            _Trial = session.Trials[trialIndex];
            InitializeComponent();
            _ErrorProvider = errorProvider;
            //cmbTrialCount.SelectedIndex = 0;
            txtDuration.Text = _Trial.Duration.ToString();
            gbTrial.Text = String.Format("Trial: {0}", _Trial.Name);
            txtName.Text = _Trial.Name;
            txtName.Enabled = (session.Trials.Count == 1) ? false : true;
        }

        public void Save()
        {
            _Trial.Duration = Int32.Parse(txtDuration.Text);
            _Trial.Name = txtName.Text;
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            gbTrial.Text = String.Format("Trial: {0}", txtName.Text);
        }
    }
}
