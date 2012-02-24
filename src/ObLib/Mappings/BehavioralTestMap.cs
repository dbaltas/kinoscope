using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class BehavioralTestMap : ClassMap<BehavioralTest>
    {
        public BehavioralTestMap()
        {
            Id(x => x.Id);
            References(x => x.Project).Column("ProjectId");
            References(x => x.BehavioralTestType).Column("BehavioralTestTypeId");
            Map(x => x.Name);
            Map(x => x.Tm);
            HasMany(x => x.Sessions).KeyColumn("BehavioralTestId").Cascade.AllDeleteOrphan();
        }
    }
}