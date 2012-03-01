using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class RunMap : ClassMap<Run>
    {
        public RunMap()
        {
            Id(x => x.Id);
            References(x => x.Trial).UniqueKey("UQ_Run_Trial_Subject"); ;
            References(x => x.Subject).UniqueKey("UQ_Run_Trial_Subject");
            Map(x => x.Tm);
            HasMany(x => x.RunEvents).Cascade.AllDeleteOrphan();
        }
    }
}