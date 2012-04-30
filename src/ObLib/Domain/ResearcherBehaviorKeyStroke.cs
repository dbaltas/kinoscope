using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
    public class ResearcherBehaviorKeyStroke : ActiveRecordBase<ResearcherBehaviorKeyStroke>
    {
        public virtual Researcher Researcher { get; set; }
        public virtual Behavior Behavior { get; set; }
        public virtual string KeyStroke { get; set; }

        public virtual BehavioralTestType BehavioralTestType { get { return Behavior.BehavioralTestType; } }

        public static List<ResearcherBehaviorKeyStroke> AllForListForm()
        {
            List<ResearcherBehaviorKeyStroke> list = new List<ResearcherBehaviorKeyStroke>();
            foreach (Behavior behavior in Behavior.All())
            {
                bool foundAsKeyStroke = false;
                foreach (ResearcherBehaviorKeyStroke researcherBehaviorKeyStroke in Researcher.Current.ResearcherBehaviorKeyStrokes)
                {
                    if (researcherBehaviorKeyStroke.Behavior == behavior)
                    {
                        list.Add(researcherBehaviorKeyStroke);
                        foundAsKeyStroke = true;
                    }
                }
                if (!foundAsKeyStroke)
                {
                    list.Add(new ResearcherBehaviorKeyStroke(){Behavior = behavior, Researcher = Researcher.Current, KeyStroke = behavior.DefaultKeyStroke});
                }
            }
            return list;
        }

        public override void Delete()
        {
            Researcher.ResearcherBehaviorKeyStrokes.Remove(this);
            Researcher.Save();

            Behavior.ResearcherBehaviorKeyStrokes.Remove(this);
            Behavior.Save();

            base.Delete();
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Behavior, KeyStroke);
        }
    }
}
