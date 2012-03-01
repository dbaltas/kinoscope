using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class RunMap : ClassMap<Run>
    {
        public RunMap()
        {
            Id(x => x.Id);
            References(x => x.Trial);
            References(x => x.Subject);
            Map(x => x.Tm);
            HasMany(x => x.RunEvents).Cascade.AllDeleteOrphan();
        }
    }
}