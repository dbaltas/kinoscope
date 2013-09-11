using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace ObLib.Export
{
    public class ExportTimeBin
    {
        int binDuration = -1;
        List<TimeBin> timeBins;
        private Run run;
        protected ExportSettings exportSettings;
        protected List<RunEvent> stateRunEventsInRange;

        public ExportTimeBin(Run run, ExportSettings exportSettings, List<RunEvent> stateRunEventsInRange)
        {
            this.run = run;
            this.exportSettings = exportSettings;
            this.stateRunEventsInRange = stateRunEventsInRange;

            if (exportSettings.TimeBinDuration <= 0)
            {
                throw new IndexOutOfRangeException(String.Format("TimeBin duration: {0} out of range",
                    exportSettings.TimeBinDuration));
            }
            this.binDuration = exportSettings.TimeBinDuration * 1000;

            initializeTimeBins();
        }

        public List<TimeBin> calculateTimeBins()
        {
            RunEvent lastStateRunEvent = stateRunEventsInRange[0];

            int eventIndex = 1;
            int binIndex = 0;
            while (true)
            {
                TimeBin currentBin = timeBins[binIndex];

                long eventEnd = (eventIndex >= stateRunEventsInRange.Count) ? exportSettings.ExportEnd * 1000 :
                    Math.Max(stateRunEventsInRange[eventIndex].TimeTracked, exportSettings.ExportStart * 1000);

                long eventStartInBin = Math.Max(lastStateRunEvent.TimeTracked, currentBin.start);
                long eventEndInBin = Math.Min(eventEnd, currentBin.end);

                double currentEventDurationInBin = eventEndInBin - eventStartInBin;

                currentBin.stateBehaviorTotalDuration[lastStateRunEvent.Behavior] += currentEventDurationInBin;

                if (eventEnd < currentBin.end)
                {
                    if (eventIndex >= stateRunEventsInRange.Count) break;
                    lastStateRunEvent = stateRunEventsInRange[eventIndex];
                    eventIndex++;
                    continue;
                }
                else
                {
                    binIndex++;
                    if (binIndex >= timeBins.Count) break;
                    continue;
                }
            }

            return timeBins;
        }

        private void initializeTimeBins()
        {
            Trial trial = run.Trial;

            timeBins = new List<TimeBin>();

            int start = exportSettings.ExportStart * 1000;
            int end = exportSettings.ExportEnd * 1000;
            int index = start;

            while (index < end)
            {
                TimeBin timeBin = new TimeBin();
                timeBin.start = index;
                index += binDuration;
                timeBin.end = Math.Min(index, end);
                foreach (Behavior behavior in trial.Session.BehavioralTest.GetBehaviors())
                {
                    if (behavior.Type == Behavior.BehaviorType.State)
                    {
                        timeBin.stateBehaviorTotalDuration.Add(behavior, 0.0);
                    }
                }

                timeBins.Add(timeBin);
            }
        }

        public List<string> headers()
        {
            List<string> headers = new List<string>();

            foreach (var behaviorDuration in timeBins[0].stateBehaviorTotalDuration)
            {
                foreach (TimeBin timeBin in timeBins)
                {
                    headers.Add(String.Format("{0} {1}-{2}", behaviorDuration.Key.Name, 
                        timeBin.start/1000, timeBin.end/1000));                    
                }
            }

            return headers;
        }

        public List<string> data()
        {
            List<string> data = new List<string>();

            foreach (var behaviorDuration in timeBins[0].stateBehaviorTotalDuration)
            {
                foreach (TimeBin timeBin in timeBins)
                {
                    data.Add((timeBin.stateBehaviorTotalDuration[behaviorDuration.Key]/(1000.0)).ToString("F3"));
                }
            }

            return data;
        }
    }
}
