using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.Windows.Forms;

using ObLib.Domain;
using System.Threading;

namespace observador
{
    class RectanglesEventVisualiser : Panel, IEventVisualiser
    {
        private struct ColoredRectangle
        {
            public Color Color;

            public double X;
            public double Y;
            public double Width;
            public double Height;

            public bool IsEmpty;

            public ColoredRectangle(Color color, double x, double y, double width, double height)
            {
                Color = color;
                X = x;
                Y = y;
                Width = width;
                Height = height;
                IsEmpty = false;
            }

            public static ColoredRectangle Empty = new ColoredRectangle() { IsEmpty = true };

            internal Rectangle MapToArea(Size area)
            {
                return new Rectangle(
                    (int)Math.Round(X * area.Width),
                    (int)Math.Round(Y * area.Height),
                    (int)Math.Round(Width * area.Width),
                    (int)Math.Round(Height * area.Height));
            }
        }

        private List<ColoredRectangle> _oldRectangles = new List<ColoredRectangle>();
        private ColoredRectangle _lastStateRectangle = ColoredRectangle.Empty;

        private double _rowHeight;
        private double _marginInRow;
        private double _rectangleHeight;
        private long _totalMilliseconds;
        private long _millisecondsPerRow;
        private int _lastRow = 0;
        private double _lastPositionInRow = 0.0;
        private List<Behavior> _behaviors;

        public float MarginHeightPercentage { get; set; }
        public float BarHeightPercentage { get; set; }
        public float InstantEventWidthPercentage { get; set; }
        public int NumberOfRows { get; set; }
        public Color[] Colors { get; set; }
        public Color BarColor { get; set; }

        public RectanglesEventVisualiser()
        {
            _totalMilliseconds = 30000;
            MarginHeightPercentage = 0.2f;
            BarHeightPercentage = 0.2f;
            NumberOfRows = 3;
            InstantEventWidthPercentage = 0.01f;
            Colors = new Color[] { Color.Brown, Color.SandyBrown, Color.Tan, Color.Khaki, Color.Red };
            BarColor = Color.Silver;

            Paint += RectanglesEventVisualiser_Paint;
            ResizeRedraw = true;
            DoubleBuffered = true;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            BackColor = Color.LightYellow;

            CalculateDerivedFields();
            CreateBackgroundBars();
        }

        public void SetBehaviors(List<Behavior> behaviors)
        {
            _behaviors = behaviors;
        }

        private void CalculateDerivedFields()
        {
            _rowHeight = 1.0 / NumberOfRows;
            _marginInRow = _rowHeight * MarginHeightPercentage;
            _rectangleHeight = _rowHeight - 2.0 * _marginInRow;
            _millisecondsPerRow = _totalMilliseconds / NumberOfRows;
        }

        public void Start(DateTime dateTime)
        {
            CalculateDerivedFields();
            UpdateInterval(0);
        }

        public void Stop(DateTime dateTime) { }

        public void Clear()
        {
            _lastStateRectangle = ColoredRectangle.Empty;
            _oldRectangles.Clear();
            _lastPositionInRow = 0.0;
            _lastRow = 0;

            CreateBackgroundBars();
            Invalidate();
        }

        public void UpdateInterval(long milliseconds)
        {
            bool lockAquired = false;

            try
            {
                if (!(lockAquired = Monitor.TryEnter(this)))
                {
                    return;
                }

                if (_lastStateRectangle.IsEmpty)
                {
                    return;
                }

                int currentRow = (int)(milliseconds / _millisecondsPerRow);
                double positionInRow = (milliseconds % _millisecondsPerRow) / (double)_millisecondsPerRow;
                double rectangleTop = currentRow * _rowHeight + _marginInRow;

                if (currentRow == _lastRow)
                {
                    _lastStateRectangle.Width = positionInRow - _lastStateRectangle.X;
                    InvalidateRectangle(_lastStateRectangle);
                }
                else
                {
                    _lastStateRectangle.Width = 1.0 - _lastStateRectangle.X; // Spans to end of row
                    InvalidateRectangle(_lastStateRectangle);
                    _oldRectangles.Add(_lastStateRectangle);
                    _lastStateRectangle = new ColoredRectangle(
                        _lastStateRectangle.Color, 0.0, rectangleTop, 0.0, _rectangleHeight);
                    InvalidateRectangle(_lastStateRectangle);
                }

                _lastRow = currentRow;
                _lastPositionInRow = positionInRow;
            }
            finally
            {
                if (lockAquired)
                {
                    Monitor.Exit(this);
                }
            }
        }

        public void AddRunEvent(RunEvent runEvent)
        {
            Monitor.Enter(this);

            double rectangleTop = _lastStateRectangle.IsEmpty ? _marginInRow : _lastStateRectangle.Y;

            ColoredRectangle newRectangle = new ColoredRectangle(
                Colors[_behaviors.IndexOf(runEvent.Behavior) % Colors.Length],
                _lastPositionInRow, rectangleTop, 0, _rectangleHeight);

            if (runEvent.Behavior.Type == Behavior.BehaviorType.Instant)
            {
                // Half margin for Instant events
                newRectangle.Y -= _marginInRow / 2.0;
                newRectangle.Height += _marginInRow;

                newRectangle.X -= InstantEventWidthPercentage / 2.0;
                newRectangle.Width += InstantEventWidthPercentage;
                _lastStateRectangle.Width = newRectangle.X - _lastStateRectangle.X;

                _oldRectangles.Add(_lastStateRectangle);
                _oldRectangles.Add(newRectangle);

                _lastStateRectangle = new ColoredRectangle(
                    _lastStateRectangle.Color,
                    newRectangle.X + newRectangle.Width,
                    _lastStateRectangle.Y,
                    0.0,
                    _rectangleHeight);

            }
            else
            {
                if (!_lastStateRectangle.IsEmpty)
                {
                    _oldRectangles.Add(_lastStateRectangle);
                }

                _lastStateRectangle = newRectangle;
            }

            InvalidateRectangle(newRectangle);

            Monitor.Exit(this);

            UpdateInterval(runEvent.TimeTracked);
        }

        private void RectanglesEventVisualiser_Paint(object sender, PaintEventArgs e)
        {
            foreach (ColoredRectangle rectangle in _oldRectangles)
            {
                DrawColoredRectangle(rectangle, e);
            }
            if (!_lastStateRectangle.IsEmpty)
            {
                DrawColoredRectangle(_lastStateRectangle, e);
            }
        }

        private void CreateBackgroundBars()
        {
            for (int i = 0; i < NumberOfRows; ++i)
            {
                ColoredRectangle bar = new ColoredRectangle(
                    BarColor,
                    0.0,
                    _rowHeight * (i + (1 - BarHeightPercentage) / 2.0),
                    1.0,
                    _rowHeight * BarHeightPercentage);

                _oldRectangles.Add(bar);
            }
        }

        private void DrawColoredRectangle(ColoredRectangle rectangle, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(rectangle.Color);
            e.Graphics.FillRectangle(brush, rectangle.MapToArea(Size));
        }

        private void InvalidateRectangle(ColoredRectangle rectangle)
        {
            Invalidate(rectangle.MapToArea(Size));
        }

        public void SetDurationMilliseconds(int milliseconds)
        {
            _totalMilliseconds = milliseconds;
        }
    }
}
