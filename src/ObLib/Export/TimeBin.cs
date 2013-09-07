using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace ObLib.Export
{
    //TODO: move to separate class
    public class TimeBin
    {
        public long start;
        public long end;
        public Dictionary<Behavior, double> stateBehaviorTotalDuration = new Dictionary<Behavior, double>();

        public static List<TimeBin> runTimeBins(Run run)
        {
            List<TimeBin> timeBins = new List<TimeBin>();
            int totalTime = run.Trial.Duration * 1000;
            int start = 0;
            int end = totalTime;
            int binDuration = 5000;
            int index = start;

            while (index < end)
            {
                TimeBin timeBin = new TimeBin();
                timeBin.start = index;
                index += binDuration;
                timeBin.end = Math.Min(index, end);
                foreach (Behavior behavior in run.Trial.Session.BehavioralTest.GetBehaviors())
                {
                    if (behavior.Type == Behavior.BehaviorType.State)
                    {
                        timeBin.stateBehaviorTotalDuration.Add(behavior, 0.0);
                    }
                }

                timeBins.Add(timeBin);
            }

            return timeBins;
        }
    }

}
