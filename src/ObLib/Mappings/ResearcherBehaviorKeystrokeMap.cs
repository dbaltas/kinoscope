using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class ResearcherBehaviorKeyStrokeMap : ClassMap<ResearcherBehaviorKeyStroke>
    {
        public ResearcherBehaviorKeyStrokeMap()
        {
            Id(x => x.Id);
            References(x => x.Researcher);
            References(x => x.Behavior);
            Map(x => x.KeyStroke);
            Map(x => x.Tm);
        }
    }
}