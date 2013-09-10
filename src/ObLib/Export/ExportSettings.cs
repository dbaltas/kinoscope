using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace ObLib.Export
{
    public class ExportSettings
    {
        public bool UseTimeBins = false;
        public int TimeBinDuration = -1;
        public int ExportStart = -1;
        public int ExportEnd = -1;

        public ExportSettings(Trial trial, int timeBinDuration = -1, int exportStart = -1, int exportEnd = -1)
        {

            if (timeBinDuration != -1 &&
                (timeBinDuration > trial.Duration || timeBinDuration <= 0)) throw new IndexOutOfRangeException();
            if (exportStart != -1 &&
                exportStart > trial.Duration) throw new IndexOutOfRangeException();
            if (exportEnd != -1 &&
                exportStart > trial.Duration) throw new IndexOutOfRangeException();
            if (exportEnd != -1 &&
                exportEnd <= exportStart) throw new Exception("Invalid Export Range");
            this.TimeBinDuration = timeBinDuration;
            this.UseTimeBins = this.TimeBinDuration > 0;
            this.ExportStart = exportStart;
            this.ExportEnd = exportEnd;
        }
    }
}
