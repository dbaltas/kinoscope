using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace ObLib.Export
{
    public class ExportFstRun : ExportRun
    {
        public ExportFstRun(Run run, ExportSettings exportSettings)
            : base(run, exportSettings)
        {
        }

        public override List<string> Headers()
        {
            List<String> headers = base.Headers();
            // Detke Scoring
            foreach (Behavior behavior in run.Trial.Session.BehavioralTest.GetBehaviors())
            {
                if (behavior.Type == Behavior.BehaviorType.State)
                {
                    headers.Add(behavior.Name + " Score");
                }
            }

            return headers;
        }

        public override List<string> RunData()
        {
            List<String> runData = base.RunData();

            Dictionary<Behavior, int> behaviorScoring = new Dictionary<Behavior, int>();
            // Detke Scoring
            // initialize
            foreach (Behavior behavior in run.Trial.Session.BehavioralTest.GetBehaviors())
            {
                if (behavior.Type == Behavior.BehaviorType.State)
                {
                    behaviorScoring.Add(behavior, 0);
                }
            }

            int scoringInterval = 5000;
            int scoringIndex = 1;
            int eventIndex = 0;

            RunEvent lastStateRunEvent = stateRunEventsInRange[0];
            eventIndex++;

            while (true)
            {
                long eventEnd = eventIndex >= stateRunEventsInRange.Count ? exportSettings.ExportEnd * 1000 :
                    Math.Max(stateRunEventsInRange[eventIndex].TimeTracked, exportSettings.ExportStart * 1000);

                if (eventEnd < scoringIndex*scoringInterval)
                {
                    lastStateRunEvent = stateRunEventsInRange[eventIndex];
                    eventIndex++;
                    continue;
                }
                else
                {
                    scoringIndex++;
                    behaviorScoring[lastStateRunEvent.Behavior]++;
                    if (scoringIndex*scoringInterval > exportSettings.ExportEnd * 1000) break;
                    continue;
                }
            }

            foreach (var behaviorScore in behaviorScoring)
            {
                runData.Add(behaviorScore.Value.ToString());
            }

            return runData;
        }

    }
}
