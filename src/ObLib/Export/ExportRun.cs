using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace ObLib.Export
{
    public class ExportRun
    {
        protected const double _LATENCY_TIME_TO_IGNORE_IN_SECONDS = 10;
        protected const double _LATENCY_MINIMUM_DURATION_IN_SECONDS = 3;

        protected Run run;
        protected ExportSettings exportSettings;

        public static ExportRun Create(Run run, ExportSettings exportSettings)
        {
            if (run.Trial.Session.BehavioralTest.BehavioralTestType == BehavioralTestType.Fst)
            {
                return new ExportFstRun(run, exportSettings);
            }
            return new ExportRun(run, exportSettings);
        }

        protected ExportRun(Run run, ExportSettings exportSettings)
        {
            this.run = run;
            this.exportSettings = exportSettings;
        }

        public virtual List<string> Headers()
        {
            Trial trial = run.Trial;
            List<string> headers = new List<string>();
            BehavioralTest behavioralTest = trial.Session.BehavioralTest;

            headers.Add("Project");
            headers.Add("SubjectID");
            headers.Add("SubjectGroup");
            headers.Add("Strain");
            headers.Add("Sex");
            headers.Add("TrialName");
            headers.Add("TrialDuration");
            headers.Add("DateRun");
            headers.Add("TimeRun");
            headers.Add("Number of Events");

            // Duration
            foreach (Behavior behavior in behavioralTest.GetBehaviors())
            {
                if (behavior.Type == Behavior.BehaviorType.State)
                {
                    headers.Add(behavior.Name + " Duration");
                }
            }

            // Frequency
            foreach (Behavior behavior in behavioralTest.GetBehaviors())
            {
                headers.Add(behavior.Name + " Frequency");
            }

            // Latency
            foreach (Behavior behavior in behavioralTest.GetBehaviors())
            {
                if (behavior.Type == Behavior.BehaviorType.State)
                {
                    headers.Add(behavior.Name + " Latency");
                }
            }

            if (exportSettings.useTimeBins)
            {
                if (trial.Runs.Count > 0)
                {
                    ExportTimeBin exportTimeBin = new ExportTimeBin(trial.Runs[0], exportSettings.timeBinDuration);
                    headers.AddRange(exportTimeBin.headers());
                }
            }
            return headers;
        }

        public virtual List<string> RunData()
        {
            List<string> data = new List<string>();
            Dictionary<Behavior, int> behaviorFrequency = new Dictionary<Behavior, int>();
            Dictionary<Behavior, double> stateBehaviorTotalDuration = new Dictionary<Behavior, double>();
            Dictionary<Behavior, double?> stateBehaviorLatency = new Dictionary<Behavior, double?>();

            data.Add(run.Trial.Session.BehavioralTest.Project.ToString());
            data.Add(run.Subject.ToString());
            string subjectGroup = "";
            if (run.Subject.SubjectGroup != null)
            {
                subjectGroup = run.Subject.SubjectGroup.ToString();
            }
            data.Add(subjectGroup);
            data.Add(run.Subject.Strain);
            data.Add(run.Subject.Sex);
            data.Add(run.Trial.ToString());
            data.Add(run.Trial.Duration.ToString());
            data.Add(run.TmRun.ToString("dd/MM/yyyy"));
            data.Add(run.TmRun.ToString("HH:mm:ss"));
            data.Add(run.RunEvents.Count.ToString());

            // initialize counters
            foreach (Behavior behavior in run.Trial.Session.BehavioralTest.GetBehaviors())
            {
                behaviorFrequency.Add(behavior, 0);
                if (behavior.Type == Behavior.BehaviorType.State)
                {
                    stateBehaviorTotalDuration.Add(behavior, 0.0);
                    stateBehaviorLatency.Add(behavior, null);
                }
            }

            RunEvent lastStateRunEvent = run.SortedRunEvents[0];

            foreach (RunEvent runEvent in run.SortedRunEvents)
            {
                // calculate frequency
                behaviorFrequency[runEvent.Behavior]++;

                // ignore first event since we calculate diffs with previous event time
                if (runEvent.TimeTracked == 0)
                {
                    continue;
                }

                if (runEvent.Behavior.Type == Behavior.BehaviorType.State)
                {
                    double currentEventDuration = runEvent.TimeTrackedInSeconds - lastStateRunEvent.TimeTrackedInSeconds;
                    // State Behaviors Duration
                    stateBehaviorTotalDuration[lastStateRunEvent.Behavior] += currentEventDuration;

                    // Latency
                    if (runEvent.TimeTrackedInSeconds > _LATENCY_TIME_TO_IGNORE_IN_SECONDS)
                    {
                        if (currentEventDuration >= _LATENCY_MINIMUM_DURATION_IN_SECONDS)
                        {
                            if (stateBehaviorLatency[lastStateRunEvent.Behavior] == null)
                            {
                                double latencyNoticedAt = lastStateRunEvent.TimeTrackedInSeconds;
                                if (lastStateRunEvent.TimeTrackedInSeconds < _LATENCY_TIME_TO_IGNORE_IN_SECONDS)
                                {
                                    latencyNoticedAt = _LATENCY_TIME_TO_IGNORE_IN_SECONDS;
                                }
                                stateBehaviorLatency[lastStateRunEvent.Behavior] = latencyNoticedAt;
                            }
                        }
                    }

                    lastStateRunEvent = runEvent;
                }


            }

            // State Behavior Duration add the time left till the end of the run
            stateBehaviorTotalDuration[lastStateRunEvent.Behavior] += run.Trial.Duration - lastStateRunEvent.TimeTrackedInSeconds;

            // state behavior latency set to trial duration if unset
            foreach (Behavior behavior in run.Trial.Session.BehavioralTest.GetBehaviors())
            {
                if (behavior.Type == Behavior.BehaviorType.State)
                {
                    if (stateBehaviorLatency[lastStateRunEvent.Behavior] == null)
                    {
                        stateBehaviorLatency[lastStateRunEvent.Behavior] = run.Trial.Duration;
                    }
                }
            }

            // export to data array
            foreach (var behaviorTotal in stateBehaviorTotalDuration)
            {
                data.Add(behaviorTotal.Value.ToString("F3"));
            }

            foreach (var behaviorCount in behaviorFrequency)
            {
                data.Add(behaviorCount.Value.ToString());
            }

            foreach (var behaviorTime in stateBehaviorLatency)
            {
                double? latency = stateBehaviorLatency[behaviorTime.Key];
                if (latency == null)
                {
                    latency = run.Trial.Duration;
                }
                data.Add(latency.Value.ToString("F3"));
            }

            if (exportSettings.useTimeBins)
            {
                ExportTimeBin exportTimeBin = new ExportTimeBin(run, exportSettings.timeBinDuration);
                List<TimeBin> timeBins = exportTimeBin.calculateTimeBins();
                data.AddRange(exportTimeBin.data());
            }

            return data;
        }
    }
}
