using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class ResearcherBehaviorKeyStrokeMap : ClassMap<ResearcherBehaviorKeyStroke>
    {
        public ResearcherBehaviorKeyStrokeMap()
        {
            Id(x => x.Id);
            References(x => x.Researcher).Column("ResearcherId");
            References(x => x.Behavior).Column("BehaviorId");
            Map(x => x.KeyStroke);
            Map(x => x.Tm);
        }
    }
}