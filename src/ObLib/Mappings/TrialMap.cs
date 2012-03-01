using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class TrialMap : ClassMap<Trial>
    {
        public TrialMap()
        {
            Id(x => x.Id);
            References(x => x.Session);
            Map(x => x.Name);
            Map(x => x.Duration);
            Map(x => x.Tm);
            HasMany(x => x.Runs).Cascade.AllDeleteOrphan();
        }
    }
}