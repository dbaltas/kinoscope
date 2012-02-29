﻿using System;
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
        private Run _run;
        private List<RunEvent> _runEvents = new List<RunEvent>();
        private Stopwatch _stopwatch = new Stopwatch();
        private bool _running = false;
        private IEventVisualiser _eventVisualiser = new TextEventVisualiser();
        private List<Behavior> _allowedBehaviors = new List<Behavior>();

        public RunForm(Run run)
        {
            _run = run;
            BehavioralTestType behavioralTestType = _run.Trial.Session.BehavioralTest.BehavioralTestType;
            foreach (Behavior behavior in Behavior.All())
            {
                if (behavior.BehavioralTestType == behavioralTestType)
                {
                    _allowedBehaviors.Add(behavior);
                }
            }

            InitializeComponent();
            Controls.Add(_eventVisualiser as Control);
            _eventVisualiser.SetDimensions(12, 41, 713, 253);
            //(_eventVisualiser as Control).KeyDown += RunForm_KeyDown;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Stop();
            Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            _run.Tm = DateTime.Now;
            _run.AddRunEvents(_runEvents);
            _run.Trial.Save();
            Close();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            Start();
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
            if (_running)
            {
                Behavior behavior = GetBehaviorByKeyStroke(e.KeyCode);

                if (behavior != null)
                {
                    RunEvent runEvent = new RunEvent() { Behavior = behavior, Run = _run, Tm = DateTime.Now };
                    _runEvents.Add(runEvent);
                    _eventVisualiser.AddRunEvent(runEvent);
                }
            }
        }

        private Behavior GetBehaviorByKeyStroke(Keys keyCode)
        {
            KeysConverter kc = new KeysConverter();
            string keyChar = kc.ConvertToString(keyCode);
            // TODO: Check if keyValue is the KeyStroke of any current Researcher's ResearcherBehaviorKeyStroke.
            return _allowedBehaviors.Find((behavior) => behavior.DefaultKeyStroke == keyChar);
        }

        private void RefreshTimerLabel()
        {
            lblTimer.Text = string.Format("{0:00}:{1:00}:{2:00}",
                _stopwatch.Elapsed.Hours,
                _stopwatch.Elapsed.Minutes,
                _stopwatch.Elapsed.Seconds);
        }

        private void Start()
        {
            if (!_running)
            {
                bSave.Enabled = false;
                _stopwatch.Start();
                timer.Start();
                _eventVisualiser.Start(DateTime.Now);
                _running = true;
            }
        }

        private void Stop()
        {
            if (_running)
            {
                _running = false;
                _eventVisualiser.Stop(DateTime.Now);
                timer.Stop();
                _stopwatch.Stop();
                bSave.Enabled = true;
                RefreshTimerLabel();
                bStart.Enabled = false;
            }
        }

        private void Reset()
        {
            Stop();

            _stopwatch.Reset();
            _runEvents.Clear();
            RefreshTimerLabel();
            bStart.Enabled = true;
        }
    }
}
