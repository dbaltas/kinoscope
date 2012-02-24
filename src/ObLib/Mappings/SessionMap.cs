using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class SessionMap : ClassMap<Session>
    {
        public SessionMap()
        {
            Id(x => x.Id);
            References(x => x.BehavioralTest).Column("BehavioralTestId");
            Map(x => x.Name);
            Map(x => x.Tm);
            HasMany(x => x.Trials).KeyColumn("SessionId").Cascade.AllDeleteOrphan();
        }
    }
}