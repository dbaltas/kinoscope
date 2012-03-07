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

                cbBehavior.SelectedItem = runEvent.Behavior;
                txtTimeTracked.Text = runEvent.TimeTracked.ToString();
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
                RunEvent runEvent = _runEvent ?? new RunEvent();

                runEvent.Behavior = (Behavior)cbBehavior.SelectedItem;
                runEvent.TimeTracked = int.Parse(txtTimeTracked.Text);

                if (_runEvent == null)
                {
                    _run.AddRunEvent(runEvent);
                }

                _run.Save();

                this.Close();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
    }
}
