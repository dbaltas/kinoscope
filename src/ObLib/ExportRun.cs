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
        public void exportRun(Run run)
        {
            string headerRow = String.Join<String>("\t", 
                fstHeaders(run.Trial.Session.BehavioralTest));
            string dataRow = String.Join<String>("\t", 
                fstRun(run));

            string exportFilename = String.Format(@"../export/{0}-{1}-{2}.csv",
                run.Trial.Session.BehavioralTest.Project,
                run.Trial,
                run.Subject);

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

            string exportFilename = String.Format(@"../export/{0}-{1}.csv",
                trial.Session.BehavioralTest.Project,
                trial);

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

            foreach (Behavior behavior in behavioralTest.GetBehaviors())
            {
                if (behavior.Type == Behavior.BehaviorType.State)
                {
                    headers.Add(behavior.Name + " Duration");
                }
            }

            foreach (Behavior behavior in behavioralTest.GetBehaviors())
            {
                headers.Add(behavior.Name + " Frequency");
            }

            return headers;
        }

        List<string> fstRun(Run run)
        {
            List<string> data = new List<string>();
            Dictionary<Behavior, int> behaviorFrequency = new Dictionary<Behavior, int>();
            Dictionary<Behavior, long> stateBehaviorTotalDuration = new Dictionary<Behavior, long>();

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

            List<RunEvent> sortedRunEvents = new List<RunEvent>(run.RunEvents);
            sortedRunEvents.Sort(new Comparison<RunEvent>((re1, re2) => (int)(re1.TimeTracked - re2.TimeTracked)));

            foreach (Behavior behavior in run.Trial.Session.BehavioralTest.GetBehaviors())
            {
                behaviorFrequency.Add(behavior, 0);
                if (behavior.Type == Behavior.BehaviorType.State)
                {
                    stateBehaviorTotalDuration.Add(behavior, 0);
                }
            }

            RunEvent lastStateRunEvent = sortedRunEvents[0];
            foreach (RunEvent runEvent in sortedRunEvents)
            {
                behaviorFrequency[runEvent.Behavior]++;

                if (runEvent.TimeTracked == 0)
                {
                    continue;
                }

                if (runEvent.Behavior.Type == Behavior.BehaviorType.State)
                {
                    // State Behaviors tracked other than the first.
                    stateBehaviorTotalDuration[lastStateRunEvent.Behavior] += runEvent.TimeTracked - lastStateRunEvent.TimeTracked;
                    lastStateRunEvent = runEvent;
                }
            }
            // add the time left till the end of the run
            stateBehaviorTotalDuration[lastStateRunEvent.Behavior] += run.Trial.Duration * 1000 - lastStateRunEvent.TimeTracked;

            foreach (var behaviorTotal in stateBehaviorTotalDuration)
            {
                data.Add(behaviorTotal.Value.ToString());
            }

            foreach (var behaviorCount in behaviorFrequency)
            {
                data.Add(behaviorCount.Value.ToString());
            }

            return data;
        }

    }
}
