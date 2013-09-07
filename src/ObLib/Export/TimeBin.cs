using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace ObLib.Export
{
    public class TimeBin
    {
        public long start;
        public long end;
        public Dictionary<Behavior, double> stateBehaviorTotalDuration = new Dictionary<Behavior, double>();
    }

}
