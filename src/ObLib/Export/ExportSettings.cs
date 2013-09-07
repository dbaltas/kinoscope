using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Export
{
    public class ExportSettings
    {
        public bool useTimeBins = false;
        public int timeBinDuration = -1;

        public ExportSettings(int timeBinDuration = -1)
        {
            this.timeBinDuration = timeBinDuration;
            this.useTimeBins = this.timeBinDuration > 0;
        }
    }
}
