using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class ResearcherBehaviorKeyStrokeMap : ClassMap<ResearcherBehaviorKeyStroke>
    {
        public ResearcherBehaviorKeyStrokeMap()
        {
            Id(x => x.Id);
            References(x => x.Researcher).UniqueKey("UQ_ResearcherBehaviorKeyStroke_Researcher_Behavior");
            References(x => x.Behavior).UniqueKey("UQ_ResearcherBehaviorKeyStroke_Researcher_Behavior");
            Map(x => x.KeyStroke);
            Map(x => x.Tm);
        }
    }
}