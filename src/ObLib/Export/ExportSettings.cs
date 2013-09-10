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
        public int exportStart = -1;
        public int exportEnd = -1;

        public ExportSettings(Trial trial, int timeBinDuration = -1)
        {
            this.TimeBinDuration = timeBinDuration;
            this.UseTimeBins = this.TimeBinDuration > 0;
        }
    }
}
