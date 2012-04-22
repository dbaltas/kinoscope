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

        public BehavioralTestTemplateSessionControl(Session session, ErrorProvider errorProvider)
        {
            InitializeComponent();
            _ErrorProvider = errorProvider;
            cmbTrialCount.SelectedIndex = 0;
            if (session != null)
            {
                txtDuration.Text = session.Trials[0].Duration.ToString();
                _Session = session;
            }
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
        }
    }
}
