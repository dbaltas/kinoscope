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
    public partial class RunEventForm : ObWin.Form
    {
        private RunEvent _runEvent = null;
        private Run _run = null;

        public RunEventForm(Run run)
        {
            _run = run;

            InitializeComponent();

            cbBehavior.DataSource = _run.Trial.Session.BehavioralTest.GetBehaviors();
        }

        public RunEventForm(RunEvent runEvent)
            : this(runEvent.Run)
        {
            if (runEvent != null)
            {
                _runEvent = runEvent;
                _run = runEvent.Run;

                cbBehavior.SelectedItem = runEvent.Behavior;
                txtTimeTracked.Text = runEvent.TimeTrackedInSeconds.ToString("F3");
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChildren())
                {
                    ShowInputError();
                    return;
                }

                RunEvent runEvent = _runEvent ?? new RunEvent();

                runEvent.Behavior = (Behavior)cbBehavior.SelectedItem;
                runEvent.TimeTracked = (int)(1000 * double.Parse(txtTimeTracked.Text));

                if (_runEvent == null)
                {
                    _run.AddRunEvent(runEvent);
                    _run.Save();
                    if (Owner is ListForm<RunEvent>)
                    {
                        (Owner as ListForm<RunEvent>).OrderRefresh(runEvent);
                    }
                }
                else
                {
                    _runEvent.Save();
                }


                this.Close();
            }
            catch (Exception ex)
            {
                FailWithError(ex);
            }
        }

        private void txtTimeTracked_Validating(object sender, CancelEventArgs e)
        {
            double timeTracked;
            if (!double.TryParse(txtTimeTracked.Text, System.Globalization.NumberStyles.Float, null, out timeTracked)
                || timeTracked < 0
                || timeTracked > _run.Trial.Duration)
            {
                e.Cancel = true;
                errorProvider.SetError(txtTimeTracked,
                    string.Format(
                        "Invalid time tracked. Must be a non-negative number not exceeding the trial's duration ({0}).",
                        _run.Trial.Duration));
            }
            else
            {
                errorProvider.SetError(txtTimeTracked, "");
            }
        }
    }
}
