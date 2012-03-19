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
    public partial class RunForm : ObWin.Form
    {
        private enum RunStatus { Ready, Running, Paused, Stopped, Saved }

        private Run _run;
        private DateTime _startTm;
        private List<RunEvent> _runEvents = new List<RunEvent>();
        private RunStatus _runStatus = RunStatus.Ready;
        private Stopwatch _stopwatch = new Stopwatch();
        private List<IEventVisualiser> _eventVisualisers = new List<IEventVisualiser>();
        private List<Behavior> _allowedBehaviors = new List<Behavior>();
        private Behavior _lastStateBehavior;
        private int _durationMilliseconds;
        private BehaviorColorAssigner _behaviorColorAssigner;

        public RunForm(Run run)
        {
            _run = run;
            _durationMilliseconds = run.Trial.Duration * 1000;

            InitializeAllowedBehaviors();

            _behaviorColorAssigner = new BehaviorColorAssigner(_allowedBehaviors,
                new Color[] { Color.Coral, Color.MediumSeaGreen, Color.PaleGoldenrod, Color.DarkSeaGreen, Color.Gray });

            InitializeComponent();

            InitializeEventVisualisers();

            RefreshStateBehaviorLabel(null);

            lblSubjectCode.Text = run.Subject.Code;

            SetStatus(RunStatus.Ready);
        }

        #region Control initialization methods

        private void InitializeAllowedBehaviors()
        {
            _allowedBehaviors = _run.Trial.Session.BehavioralTest.GetBehaviors();
        }

        private void InitializeEventVisualisers()
        {
            _eventVisualisers.Add(eventVisualiserRectangles);
            _eventVisualisers.Add(eventVisualiserText);
            _eventVisualisers.Add(eventVisualiserBehaviorList);

            foreach (IEventVisualiser eventVisualiser in _eventVisualisers)
            {
                eventVisualiser.SetBehaviors(_allowedBehaviors);
                eventVisualiser.SetDurationMilliseconds(_durationMilliseconds);
                eventVisualiser.SetBehaviorColorAssigner(_behaviorColorAssigner);
            }
        }

        #endregion

        #region Events

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_runStatus == RunStatus.Running)
            {
                Pause();

                DialogResult dialogResult = MessageBox.Show(
                    "A run is currently in progress. Are you sure you want to cancel it and exit?",
                    "Run in progress",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    Resume();
                    return;
                }
            }

            if (_runStatus == RunStatus.Stopped)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "The run has not been saved. Are you sure you want to discard it and exit?",
                    "Run not saved",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
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

        private void bClear_Click(object sender, EventArgs e)
        {
            Pause();

            DialogResult dialogResult = MessageBox.Show(
                "The run data will be deleted. Are you sure you want to discard it and start again?",
                "Reset Run",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Reset();
            }
            else
            {
                Resume();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_stopwatch.ElapsedMilliseconds > _durationMilliseconds)
            {
                Stop();
                MessageBox.Show("The run has ended.", "Info");
            }
            else
            {
                RefreshTimerLabel();
                foreach (IEventVisualiser eventVisualiser in _eventVisualisers)
                {
                    eventVisualiser.UpdateInterval(_stopwatch.ElapsedMilliseconds);
                }
            }
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
                foreach (IEventVisualiser eventVisualiser in _eventVisualisers)
                {
                    eventVisualiser.Start(DateTime.Now);
                }
                _startTm = DateTime.Now;
                SetStatus(RunStatus.Running);
            }
        }

        private void Stop()
        {
            if (_runStatus == RunStatus.Running)
            {
                timer.Stop();
                _stopwatch.Stop();
                foreach (IEventVisualiser eventVisualiser in _eventVisualisers)
                {
                    eventVisualiser.UpdateInterval(_durationMilliseconds);
                    eventVisualiser.Stop(DateTime.Now);
                }
                bSave.Enabled = true;
                RefreshTimerLabel();
                RefreshStateBehaviorLabel(null);
                SetStatus(RunStatus.Stopped);
            }
        }

        private void Pause()
        {
            if (_runStatus == RunStatus.Running)
            {
                timer.Stop();
                _stopwatch.Stop();
                RefreshTimerLabel();
                SetStatus(RunStatus.Paused);
            }
        }

        private void Resume()
        {
            if (_runStatus == RunStatus.Paused)
            {
                _stopwatch.Start();
                timer.Start();
                SetStatus(RunStatus.Running);
            }
        }

        private void Reset()
        {
            Stop();

            bSave.Enabled = false;
            _stopwatch.Reset();
            foreach (IEventVisualiser eventVisualiser in _eventVisualisers)
            {
                eventVisualiser.Clear();
            }
            _runEvents.Clear();
            _lastStateBehavior = null;
            RefreshTimerLabel();
            SetStatus(RunStatus.Ready);
        }

        private void Save()
        {
            _run.TmRun = _startTm;
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

            long elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
            if (_runStatus == RunStatus.Running && elapsedMilliseconds <= _durationMilliseconds)
            {
                if (behavior != null && behavior != _lastStateBehavior)
                {
                    RunEvent runEvent = new RunEvent()
                    {
                        Behavior = behavior,
                        Run = _run,
                        TimeTracked = firstKey ? 0 : elapsedMilliseconds
                    };
                    _runEvents.Add(runEvent);
                    foreach (IEventVisualiser eventVisualiser in _eventVisualisers)
                    {
                        eventVisualiser.AddRunEvent(runEvent);
                    }

                    if (behavior.Type == Behavior.BehaviorType.State)
                    {
                        _lastStateBehavior = behavior;
                        RefreshStateBehaviorLabel(behavior);
                    }
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
            // Don't show excess milliseconds after timeout (assumes that timer interval is faster than second).
            int millisecondsToShow =
                _stopwatch.ElapsedMilliseconds > _durationMilliseconds ? 0 : _stopwatch.Elapsed.Milliseconds;

            lblTimer.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                _stopwatch.Elapsed.Hours,
                _stopwatch.Elapsed.Minutes,
                _stopwatch.Elapsed.Seconds,
                millisecondsToShow);
        }

        private void RefreshStateBehaviorLabel(Behavior behavior)
        {
            if (behavior == null)
            {
                lblStateBehavior.Text = "";
            }
            else
            {
                lblStateBehavior.Text = behavior.ToString();
                //lblStateBehavior.ForeColor = _behaviorColorAssigner.GetBehaviorColor(behavior);
            }
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
