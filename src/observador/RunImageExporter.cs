using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

using ObLib.Domain;

namespace observador
{
    public class RunImageExporter
    {
        private Color[] _colors =
            new Color[] { Color.Black, Color.DimGray, Color.Gainsboro, Color.DarkGray, Color.Black };
        private string _FolderPath;

        public string FolderPath
        {
            get
            {
                return _FolderPath;
            }
            set
            {
                if (!System.IO.Directory.Exists(value))
                {
                    System.IO.Directory.CreateDirectory(value);
                }
                _FolderPath = value;
            }
        }

        public int Export(Project project)
        {
            IList<Run> runs = project.CompleteRuns;

            foreach (Run run in runs)
            {
                Export(run);
            }
            return runs.Count;
        }

        private void Export(Run run)
        {
            List<Behavior> behaviors = run.Trial.Session.BehavioralTest.GetBehaviors();

            IEventVisualiser visualiser = new RectanglesEventVisualiser()
            {
                Size = new Size(1000, 50),
                NumberOfRows = 1,
                BackColor = Color.White,
                InstantEventWidthPercentage = 0.002f
            };

            visualiser.SetDurationMilliseconds(run.Trial.Duration * 1000);
            visualiser.SetBehaviors(behaviors);
            visualiser.SetBehaviorColorAssigner(
                new BehaviorColorAssigner(behaviors, _colors));

            visualiser.Start(DateTime.Now);

            foreach (RunEvent runEvent in run.RunEvents.OrderBy((re) => re.TimeTracked))
            {
                visualiser.AddRunEvent(runEvent);
            }

            visualiser.UpdateInterval(run.Trial.Duration * 1000);
            visualiser.Stop(DateTime.Now);

            string fileName = string.Format("{0}-{1}-{2}.png", run.Trial.Session.BehavioralTest.Project, run.Trial.Session.BehavioralTest, run.Subject);

            Control visualiserControl = visualiser as Control;

            int width = visualiserControl.Size.Width;
            int height = visualiserControl.Size.Height;

            Bitmap bm = new Bitmap(width, height);
            visualiserControl.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

            string fullPath = string.Format("{0}\\{1}", FolderPath, fileName);
            bm.Save(fullPath, ImageFormat.Png);
        }
    }
}
