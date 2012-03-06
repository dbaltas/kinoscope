using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class BehaviorMap : ClassMap<Behavior>
    {
        public BehaviorMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Type);
            References(x => x.BehavioralTestType).UniqueKey("UQ_Behavior_BehavioralTestType_DefaultKeyStroke");
            Map(x => x.DefaultKeyStroke).UniqueKey("UQ_Behavior_BehavioralTestType_DefaultKeyStroke");
            Map(x => x.Tm);
            HasMany(x => x.ResearcherBehaviorKeyStrokes).Cascade.AllDeleteOrphan();
        }
    }
}