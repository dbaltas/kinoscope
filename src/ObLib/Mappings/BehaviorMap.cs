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
            References(x => x.BehavioralTestType).Column("BehavioralTestTypeId");
            Map(x => x.DefaultKeyStroke);
            Map(x => x.Tm);
        }
    }
}