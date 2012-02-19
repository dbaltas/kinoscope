using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class TrialMap : ClassMap<Trial>
    {
        public TrialMap()
        {
            Id(x => x.Id);
            References(x => x.Session).Column("SessionId");
            Map(x => x.Name);
            Map(x => x.Duration);
            Map(x => x.Tm);
        }
    }
}