using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using ObLib.Domain;
using ObLib;

namespace observador
{
    public partial class RunForm : Form
    {
        private enum RunStatus { Ready, Running, Stopped, Saved }

        private Run _run;
        private DateTime _startTm;
        private List<RunEvent> _runEvents = new List<RunEvent>();
        private RunStatus _runStatus = RunStatus.Ready;
        // Could be useful if we decide to implement Pause functionality
        private Stopwatch _stopwatch = new Stopwatch();
        private IEventVisualiser _eventVisualiser = new TextEventVisualiser();
        private List<Behavior> _allowedBehaviors = new List<Behavior>();

        public RunForm(Run run)
        {
            _run = run;

            InitializeAllowedBehaviors();

            InitializeComponent();

            InitializeEventVisualiser();

            InitializeBehaviorList();

            SetStatus(RunStatus.Ready);
        }

        #region Control initialization methods

        private void InitializeAllowedBehaviors()
        {
            BehavioralTestType behavioralTestType = _run.Trial.Session.BehavioralTest.BehavioralTestType;
            foreach (Behavior behavior in Behavior.All())
            {
                if (behavior.BehavioralTestType == behavioralTestType)
                {
                    // TODO: Modify behavior.KeyStroke based on current Researcher's ResearcherBehaviorKeyStrokes.
                    _allowedBehaviors.Add(behavior);
                }
            }
        }

        private void InitializeEventVisualiser()
        {
            Control eventVisualiserControl = _eventVisualiser as Control;

            pnlEventVisualiser.Controls.Add(eventVisualiserControl);

            eventVisualiserControl.Width = eventVisualiserControl.Parent.Width;
            eventVisualiserControl.Height = eventVisualiserControl.Parent.Height;

            eventVisualiserControl.Anchor =
                AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void InitializeBehaviorList()
        {
            dgvBehaviors.AutoGenerateColumns = false;
            dgvBehaviors.DataSource = _allowedBehaviors;
        }

        #endregion

        #region Events

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_runStatus == RunStatus.Running)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "A run is currently in progress. Are you sure you want to cancel it and exit?",
                    "Run in progress",
                    MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (_runStatus == RunStatus.Stopped)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "The run has not been saved. Are you sure you want to discard it and exit?",
                    "Run not saved",
                    MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            Stop();
            base.OnFormClosing(e);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            RefreshTimerLabel();
            _eventVisualiser.UpdateInterval(_stopwatch.ElapsedMilliseconds);
        }

        private void RunForm_KeyDown(object sender, KeyEventArgs e)
        {
            Key(e.KeyCode);
        }

        #endregion

        #region Command methods

        private void Start()
        {
            if (_runStatus == RunStatus.Ready)
            {
                _stopwatch.Start();
                timer.Start();
                _eventVisualiser.Start(DateTime.Now);
                _startTm = DateTime.Now;
                SetStatus(RunStatus.Running);
            }
        }

        private void Stop()
        {
            if (_runStatus == RunStatus.Running)
            {
                _eventVisualiser.Stop(DateTime.Now);
                timer.Stop();
                _stopwatch.Stop();
                bSave.Enabled = true;
                RefreshTimerLabel();
                SetStatus(RunStatus.Stopped);
            }
        }

        private void Reset()
        {
            Stop();

            bSave.Enabled = false;
            _stopwatch.Reset();
            _eventVisualiser.Clear();
            _runEvents.Clear();
            RefreshTimerLabel();
            SetStatus(RunStatus.Ready);
        }

        private void Save()
        {
            _run.Tm = _startTm;
            _run.SetRunEvents(_runEvents);
            _run.Trial.Save();
            SetStatus(RunStatus.Saved);
        }

        private void Key(Keys key)
        {
            bool firstKey = false;
            Behavior behavior = GetBehaviorByKeyStroke(key);

            if (_runStatus == RunStatus.Ready
                && behavior != null
                && behavior.Type == Behavior.BehaviorType.State)
            {
                Start();
                firstKey = true;
            }

            if (_runStatus == RunStatus.Running)
            {
                if (behavior != null)
                {
                    RunEvent runEvent = new RunEvent()
                    {
                        Behavior = behavior,
                        Run = _run,
                        Tm = DateTime.Now,
                        TimeTracked = firstKey ? 0 : _stopwatch.ElapsedMilliseconds
                    };
                    _runEvents.Add(runEvent);
                    _eventVisualiser.AddRunEvent(runEvent);
                }
            }
        }

        #endregion

        #region Helper methods

        private Behavior GetBehaviorByKeyStroke(Keys keyCode)
        {
            KeysConverter kc = new KeysConverter();
            string keyChar = kc.ConvertToString(keyCode);
            return _allowedBehaviors.Find((behavior) => behavior.KeyStroke == keyChar);
        }

        private void RefreshTimerLabel()
        {
            lblTimer.Text = string.Format("{0:00}:{1:00}:{2:00}",
                _stopwatch.Elapsed.Hours,
                _stopwatch.Elapsed.Minutes,
                _stopwatch.Elapsed.Seconds);
        }

        private void SetStatus(RunStatus status)
        {
            _runStatus = status;

            switch (status)
            {
                case RunStatus.Ready:
                    tssStatus.Text = "Ready. Press any state behavior key to launch run.";
                    break;
                case RunStatus.Running:
                    tssStatus.Text = "Run is in progress.";
                    break;
                case RunStatus.Stopped:
                    tssStatus.Text = "Run is complete.";
                    break;
            }
        }

        #endregion
    }
}
