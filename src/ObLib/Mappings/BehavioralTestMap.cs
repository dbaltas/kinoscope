using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class BehavioralTestMap : ClassMap<BehavioralTest>
    {
        public BehavioralTestMap()
        {
            Id(x => x.Id);
            References(x => x.Project);
            References(x => x.BehavioralTestType);
            Map(x => x.Name);
            Map(x => x.Tm);
            HasMany(x => x.Sessions).Cascade.AllDeleteOrphan();
        }
    }
}