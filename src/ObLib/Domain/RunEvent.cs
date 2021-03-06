﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class RunEvent : ActiveRecordBase<RunEvent>
    {
        public virtual Run Run { get; set; }
        public virtual Behavior Behavior { get; set; }
        public virtual long TimeTracked { get; set; }

        public virtual double TimeTrackedInSeconds { get { return TimeTracked / 1000.0; } }

        public override void Delete()
        {
            Run.RunEvents.Remove(this);
            Run.Save();
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Run, Behavior);
        }
    }
}
