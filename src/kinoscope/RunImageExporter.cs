using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

using ObLib.Domain;

namespace kinoscope
{
    public class RunImageExporter
    {
        private Color[] _colors =
            new Color[] { Color.Black, Color.Red, Color.Blue, Color.Yellow, Color.Green };
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
            /*
            string searchPatern = String.Format("*{0}*.png", project);
            string[] files = System.IO.Directory.GetFiles(_FolderPath, searchPatern);
            System.Drawing.Bitmap stitchedImage = Combine(files);
            string fileName = string.Format("all-runs.png");
            string fullPath = string.Format("{0}\\{1}", FolderPath, fileName);

            stitchedImage.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            */
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

        public static System.Drawing.Bitmap Combine(string[] files)
        {
            //read all images into memory
            List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
            System.Drawing.Bitmap finalImage = null;

            try
            {
                int width = 0;
                int height = 0;

                foreach (string image in files)
                {
                    //create a Bitmap from the file and add it to the list
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(image);

                    //update the size of the final bitmap
                    height += bitmap.Height;
                    width = bitmap.Width > width ? bitmap.Width : width;

                    images.Add(bitmap);
                }

                //create a bitmap to hold the combined image
                finalImage = new System.Drawing.Bitmap(width, height);

                //get a graphics object from the image so we can draw on it
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    //set background color
                    g.Clear(System.Drawing.Color.Black);

                    //go through each image and draw it on the final image
                    int offset = 0;
                    foreach (System.Drawing.Bitmap image in images)
                    {
                        g.DrawImage(image,
                          new System.Drawing.Rectangle(0, offset, image.Width, image.Height));
                        offset += image.Height;
                    }
                }

                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (System.Drawing.Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }
    }
}
