using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using ObLib.Domain;

namespace ObLib.Export
{
    public class Exporter
    {
        public const string EXPORT_DIRECTORY = @"../export/";
        private ExportSettings exportSettings;

        public Exporter(ExportSettings exportSettings = null)
        {
            this.exportSettings = (null != exportSettings) ? exportSettings : new ExportSettings();
        }

        public void export(Run run)
        {
            ExportRun exportRun = ExportRun.Create(run, exportSettings);
            string headerRow = String.Join<String>("\t", 
                exportRun.Headers());
            string dataRow = String.Join<String>("\t", 
                exportRun.RunData());

            string exportFilename = exportFile(run);

            string exportDirectory = Path.GetDirectoryName(exportFilename);
            if (!Directory.Exists(exportDirectory))
            {
                Directory.CreateDirectory(exportDirectory);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(exportFilename))
            {
                file.WriteLine(headerRow);
                file.WriteLine(dataRow);
            }
        }

        public void export(Trial trial)
        {
            ExportRun exportRun = ExportRun.Create(trial.Runs[0], exportSettings);

            List<string> dataRows = new List<string>();
            string headerRow = String.Join<String>("\t",
                exportRun.Headers());

            foreach (Run run in trial.Runs)
            {
                exportRun = ExportRun.Create(run, exportSettings);
                if (run.Status == Run.RunStatus.Complete)
                {
                    Run.ValidationResult runValidationResult = run.Validate();
                    if (runValidationResult.IsValid)
                    {
                        dataRows.Add(String.Join<String>("\t", exportRun.RunData()));
                    }
                }
            }

            string exportFilename = exportPath(trial);

            string exportDirectory = Path.GetDirectoryName(exportFilename);
            if (!Directory.Exists(exportDirectory))
            {
                Directory.CreateDirectory(exportDirectory);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(exportFilename))
            {
                file.WriteLine(headerRow);
                foreach (string dataRow in dataRows)
                {
                    file.WriteLine(dataRow);
                }
            }
        }

        public static string ToFriendlyFilename(string filename)
        {
            string result = filename.Replace(':', '-');
            return System.Text.RegularExpressions.Regex.Replace(filename, @"[^\w\.-]", "_");
        }

        private string exportFile(Run run)
        {
            string filename = String.Format("{0}-{1}-{2}-{3}.csv",
                run.Trial.Session.BehavioralTest.Project,
                run.Trial,
                run.Subject,
                DateTime.Now.ToString("yyyyMMddHHmmss"));


            return String.Format("{0}/{1}/text/{2}",
                EXPORT_DIRECTORY,
                ToFriendlyFilename(run.Trial.Session.BehavioralTest.Project.ToString()),
                ToFriendlyFilename(filename));
        }

        private string exportPath(Trial trial)
        {
            string filename = String.Format("{0}-{1}-{2}.csv",
                trial.Session.BehavioralTest.Project,
                trial,
                DateTime.Now.ToString("yyyyMMddHHmmss"));

            return String.Format("{0}/{1}/text/{2}",
                EXPORT_DIRECTORY,
                ToFriendlyFilename(trial.Session.BehavioralTest.Project.ToString()),
                ToFriendlyFilename(filename));
        }
    }
}
