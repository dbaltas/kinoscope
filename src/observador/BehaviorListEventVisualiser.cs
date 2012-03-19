using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace observador
{
    public class BehaviorListEventVisualiser : DataGridView, IEventVisualiser
    {
        BehaviorColorAssigner _behaviorColorAssigner;
        Dictionary<Behavior, long> _stateBehaviorDurations = new Dictionary<Behavior, long>();
        Dictionary<Behavior, int> _instantBehaviorCounts = new Dictionary<Behavior, int>();
        Behavior _lastStateBehavior = null;
        long _lastMilliseconds = 0L;

        private DataGridViewTextBoxColumn BehaviorKeyStroke;
        private DataGridViewTextBoxColumn BehaviorColor;
        private DataGridViewTextBoxColumn BehaviorName;
        private DataGridViewTextBoxColumn BehaviorType;
        private DataGridViewTextBoxColumn DurationCount;

        public BehaviorListEventVisualiser()
        {
            InitializeColumns();
            InitializeOtherProperties();

            CellFormatting += dgv_CellFormatting;
            SizeChanged += BehaviorListEventVisualiser_SizeChanged;
        }

        void BehaviorListEventVisualiser_SizeChanged(object sender, EventArgs e)
        {
            SetLastColumnWidth();
        }

        private void InitializeColumns()
        {
            BehaviorKeyStroke = new DataGridViewTextBoxColumn();
            BehaviorColor = new DataGridViewTextBoxColumn();
            BehaviorName = new DataGridViewTextBoxColumn();
            BehaviorType = new DataGridViewTextBoxColumn();
            DurationCount = new DataGridViewTextBoxColumn();

            // 
            // BehaviorKeyStroke
            // 
            BehaviorKeyStroke.DataPropertyName = "KeyStroke";
            BehaviorKeyStroke.HeaderText = "Key";
            BehaviorKeyStroke.Name = "BehaviorKeyStroke";
            BehaviorKeyStroke.ReadOnly = true;
            BehaviorKeyStroke.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            BehaviorKeyStroke.Width = 70;
            // 
            // BehaviorColor
            // 
            BehaviorColor.HeaderText = "";
            BehaviorColor.Name = "BehaviorColor";
            BehaviorColor.ReadOnly = true;
            BehaviorColor.Width = 20;
            // 
            // BehaviorName
            // 
            BehaviorName.DataPropertyName = "Name";
            BehaviorName.HeaderText = "Name";
            BehaviorName.Name = "BehaviorName";
            BehaviorName.ReadOnly = true;
            BehaviorName.Width = 145;
            // 
            // BehaviorType
            // 
            BehaviorType.DataPropertyName = "Type";
            BehaviorType.HeaderText = "Type";
            BehaviorType.Name = "BehaviorType";
            BehaviorType.ReadOnly = true;
            BehaviorType.Width = 88;
            // 
            // DurationCount
            // 
            DurationCount.HeaderText = "Duration/Count";
            DurationCount.Name = "DurationCount";
            DurationCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DurationCount.ReadOnly = true;
            SetLastColumnWidth();

            Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                BehaviorKeyStroke,
                BehaviorColor,
                BehaviorName,
                BehaviorType,
                DurationCount});
        }

        private void InitializeOtherProperties()
        {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            ReadOnly = true;
            RowHeadersVisible = false;
            ScrollBars = ScrollBars.Vertical;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            AutoGenerateColumns = false;
        }

        private void SetLastColumnWidth()
        {
            DurationCount.Width = Width
                - BehaviorKeyStroke.Width
                - BehaviorColor.Width
                - BehaviorName.Width
                - BehaviorType.Width;
        }

        public void Start(DateTime dateTime) { }

        public void Stop(DateTime dateTime) { }

        public void Clear()
        {
            foreach (Behavior behavior in _stateBehaviorDurations.Keys.ToList())
            {
                _stateBehaviorDurations[behavior] = 0L;
            }
            foreach (Behavior behavior in _instantBehaviorCounts.Keys.ToList())
            {
                _instantBehaviorCounts[behavior] = 0;
            }

            UpdateDurationCountCells();

            _lastStateBehavior = null;
            _lastMilliseconds = 0L;
        }

        public void UpdateInterval(long milliseconds)
        {
            if (_lastStateBehavior != null)
            {
                _stateBehaviorDurations[_lastStateBehavior] += milliseconds - _lastMilliseconds;
            }
            _lastMilliseconds = milliseconds;

            UpdateDurationCountCells();
        }

        public void AddRunEvent(RunEvent runEvent)
        {
            UpdateInterval(runEvent.TimeTracked);

            switch (runEvent.Behavior.Type)
            {
                case Behavior.BehaviorType.State:
                    _lastStateBehavior = runEvent.Behavior;
                    break;
                case Behavior.BehaviorType.Instant:
                    _instantBehaviorCounts[runEvent.Behavior]++;
                    break;
            }

            UpdateDurationCountCells();
        }

        public void SetBehaviors(List<Behavior> behaviors)
        {
            DataSource = behaviors;

            _stateBehaviorDurations.Clear();
            _instantBehaviorCounts.Clear();
            foreach (Behavior behavior in behaviors)
            {
                switch (behavior.Type)
                {
                    case Behavior.BehaviorType.State:
                        _stateBehaviorDurations.Add(behavior, 0L);
                        break;
                    case Behavior.BehaviorType.Instant:
                        _instantBehaviorCounts.Add(behavior, 0);
                        break;
                }
            }
        }

        public void SetDurationMilliseconds(long milliseconds) { }

        public void SetBehaviorColorAssigner(BehaviorColorAssigner behaviorColorAssigner)
        {
            _behaviorColorAssigner = behaviorColorAssigner;
        }

        private void UpdateDurationCountCells()
        {
            foreach (DataGridViewRow row in Rows)
            {
                Behavior behavior = row.DataBoundItem as Behavior;
                row.Cells[DurationCount.Index].Value =
                    behavior.Type == Behavior.BehaviorType.State
                    ? FormatMilliseconds(_stateBehaviorDurations[behavior])
                    : _instantBehaviorCounts[behavior].ToString();
            }
        }

        private string FormatMilliseconds(long milliseconds)
        {
            return (milliseconds / 1000.0).ToString("F3");
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = Rows[e.RowIndex];
            Behavior behavior = row.DataBoundItem as Behavior;

            // Color
            switch (Columns[e.ColumnIndex].Name)
            {
                case "BehaviorColor":
                    e.CellStyle.BackColor = _behaviorColorAssigner.GetBehaviorColor(behavior);
                    break;
                case "DurationCount":
                    if (string.IsNullOrEmpty(e.Value as string))
                    {
                        e.Value = behavior.Type == Behavior.BehaviorType.State
                            ? FormatMilliseconds(0L)
                            : 0.ToString();
                    }
                    break;
            }
        }
    }
}
