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

        protected Dictionary<Behavior, int> behaviorFrequency = new Dictionary<Behavior, int>();
        protected Dictionary<Behavior, double> stateBehaviorTotalDuration = new Dictionary<Behavior, double>();
        protected Dictionary<Behavior, double?> stateBehaviorLatency = new Dictionary<Behavior, double?>();

        protected List<RunEvent> runEventsInRange
        {
            get
            {
                initializeRunEventsInRange();
                return _runEventsInRange;
            }
        }
        private List<RunEvent> _runEventsInRange;
        private List<RunEvent> _stateRunEventsInRange;



        protected List<RunEvent> stateRunEventsInRange
        {
            get
            {
                if (_stateRunEventsInRange == null)
                {
                    _stateRunEventsInRange = runEventsInRange.FindAll(new Predicate<RunEvent>(r => r.Behavior.Type == Behavior.BehaviorType.State));
                }
                return _stateRunEventsInRange;
            }
        }


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

            if (exportSettings.UseTimeBins)
            {
                if (trial.Runs.Count > 0)
                {
                    ExportTimeBin exportTimeBin = new ExportTimeBin(trial.Runs[0], exportSettings, stateRunEventsInRange);
                    headers.AddRange(exportTimeBin.headers());
                }
            }
            return headers;
        }

        public virtual List<string> RunData()
        {
            List<string> data = new List<string>();
            string subjectGroup = (run.Subject.SubjectGroup != null) ? run.Subject.SubjectGroup.ToString() : "";

            initializeCounters();
            initializeRunEventsInRange();
            calculateCounters(runEventsInRange);

            data.Add(run.Trial.Session.BehavioralTest.Project.ToString());
            data.Add(run.Subject.ToString());

            data.Add(subjectGroup);
            data.Add(run.Subject.Strain);
            data.Add(run.Subject.Sex);
            data.Add(run.Trial.ToString());
            data.Add(run.Trial.Duration.ToString());
            data.Add(run.TmRun.ToString("dd/MM/yyyy"));
            data.Add(run.TmRun.ToString("HH:mm:ss"));

            data.Add(runEventsInRange.Count.ToString());

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
                    latency = exportSettings.ExportEnd;
                }
                data.Add(latency.Value.ToString("F3"));
            }

            if (exportSettings.UseTimeBins)
            {
                ExportTimeBin exportTimeBin = new ExportTimeBin(run, exportSettings, stateRunEventsInRange);
                List<TimeBin> timeBins = exportTimeBin.calculateTimeBins();
                data.AddRange(exportTimeBin.data());
            }

            return data;
        }

        private void calculateCounters(List<RunEvent> runEventsInRange)
        {
            RunEvent lastStateRunEvent = runEventsInRange[0];

            foreach (RunEvent runEvent in runEventsInRange)
            {
                // calculate frequency
                behaviorFrequency[runEvent.Behavior]++;

                // ignore first event since we calculate diffs with previous event time
                if (runEvent.TimeTracked <= exportSettings.ExportStart * 1000)
                {
                    lastStateRunEvent = runEvent;
                    continue;
                }

                if (runEvent.Behavior.Type == Behavior.BehaviorType.State)
                {
                    double eventStart = Math.Max(lastStateRunEvent.TimeTrackedInSeconds, exportSettings.ExportStart);
                    double currentEventDuration = runEvent.TimeTrackedInSeconds - eventStart;
                    // State Behaviors Duration
                    stateBehaviorTotalDuration[lastStateRunEvent.Behavior] += currentEventDuration;

                    // Latency
                    if (runEvent.TimeTrackedInSeconds > _LATENCY_TIME_TO_IGNORE_IN_SECONDS)
                    {
                        if (currentEventDuration >= _LATENCY_MINIMUM_DURATION_IN_SECONDS)
                        {
                            if (stateBehaviorLatency[lastStateRunEvent.Behavior] == null)
                            {
                                double latencyNoticedAt = eventStart;
                                if (eventStart < _LATENCY_TIME_TO_IGNORE_IN_SECONDS)
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
            stateBehaviorTotalDuration[lastStateRunEvent.Behavior] += exportSettings.ExportEnd - lastStateRunEvent.TimeTrackedInSeconds;

            // state behavior latency set to trial duration if unset
            foreach (Behavior behavior in run.Trial.Session.BehavioralTest.GetBehaviors())
            {
                if (behavior.Type == Behavior.BehaviorType.State)
                {
                    if (stateBehaviorLatency[lastStateRunEvent.Behavior] == null)
                    {
                        stateBehaviorLatency[lastStateRunEvent.Behavior] = exportSettings.ExportEnd;
                    }
                }
            }
        }

        private void initializeCounters()
        {
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
        }

        private void initializeRunEventsInRange()
        {
            if (_runEventsInRange != null) return;

            RunEvent lastStateRunEventInRange = null;
            RunEvent tempRunEventToRemoveIfNotLastBeforeExportStart = null;
            _runEventsInRange = new List<RunEvent>(run.SortedRunEvents);

            foreach (RunEvent runEvent in run.SortedRunEvents)
            {
                if (runEvent.TimeTracked < exportSettings.ExportStart * 1000)
                {
                    if (runEvent.Behavior.Type == Behavior.BehaviorType.State) lastStateRunEventInRange = runEvent;
                    if (tempRunEventToRemoveIfNotLastBeforeExportStart != null)
                    {
                        _runEventsInRange.Remove(tempRunEventToRemoveIfNotLastBeforeExportStart);
                    }
                    tempRunEventToRemoveIfNotLastBeforeExportStart = runEvent;
                }
                if (runEvent.TimeTracked >= exportSettings.ExportEnd * 1000)
                {
                    _runEventsInRange.RemoveAll(new Predicate<RunEvent>(r => (r.TimeTracked >= runEvent.TimeTracked)));
                    break;
                }
            }
        }
    }
}
