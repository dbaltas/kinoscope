using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace ObLib.Export
{
    class ExportFstRun : ExportRun
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

    }
}
