using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using ObLib.Domain;

namespace ObLib
{
    public class ExportRun
    {
        private const double _LATENCY_TIME_TO_IGNORE_IN_SECONDS = 10;
        private const double _LATENCY_MINIMUM_DURATION_IN_SECONDS = 3;

        public const string EXPORT_DIRECTORY = @"../export/";

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

        private string exportFile(Trial trial)
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

        public void exportRun(Run run)
        {
            string headerRow = String.Join<String>("\t", 
                fstHeaders(run.Trial.Session.BehavioralTest));
            string dataRow = String.Join<String>("\t", 
                fstRun(run));

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

        public void exportTrial(Trial trial)
        {
            List<string> dataRows = new List<string>();
            string headerRow = String.Join<String>("\t",
                fstHeaders(trial.Session.BehavioralTest));

            foreach (Run run in trial.Runs)
            {
                if (run.Status == Run.RunStatus.Complete)
                {
                    Run.ValidationResult runValidationResult = run.Validate();
                    if (runValidationResult.IsValid)
                    {
                        dataRows.Add(String.Join<String>("\t", fstRun(run)));
                    }
                }
            }

            string exportFilename = exportFile(trial);

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

        List<string> fstHeaders(BehavioralTest behavioralTest)
        {
            List<string> headers = new List<string>();
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

            return headers;
        }

        List<string> fstRun(Run run)
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
            data.Add(run.TmCreated.ToString("dd/MM/yyyy"));
            data.Add(run.TmCreated.ToString("HH:mm:ss"));
            data.Add(run.RunEvents.Count.ToString());

            List<RunEvent> sortedRunEvents = new List<RunEvent>(run.RunEvents);
            sortedRunEvents.Sort(new Comparison<RunEvent>((re1, re2) => (int)(re1.TimeTracked - re2.TimeTracked)));

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

            RunEvent lastStateRunEvent = sortedRunEvents[0];
            foreach (RunEvent runEvent in sortedRunEvents)
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

            return data;
        }

        public string ToFriendlyFilename(string filename)
        {
            string result = filename.Replace(':', '-');
            return System.Text.RegularExpressions.Regex.Replace(filename, @"[^\w\.-]", "_");
        }
    }
}
