using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace observador
{
    public class TextEventVisualiser : TextBox, IEventVisualiser
    {
        public TextEventVisualiser()
        {
            ReadOnly = true;
            Multiline = true;
        }

        public void Start(DateTime dateTime)
        {
            AppendLine(string.Format("Starting: {0}", dateTime.ToString()));
        }

        public void Stop(DateTime dateTime)
        {
            AppendLine(string.Format("Stopping: {0}", dateTime.ToString()));
        }

        public void UpdateInterval(long milliseconds) { }

        public void SetDimensions(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public void AddRunEvent(RunEvent runEvent)
        {
            AppendLine(string.Format("Behavior {0} at time {1}.", runEvent.Behavior, runEvent.Tm));
        }

        private void AppendLine(string line)
        {
            AppendText(line);
            AppendText(Environment.NewLine);
        }
    }
}
