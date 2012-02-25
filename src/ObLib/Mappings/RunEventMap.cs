using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class RunEventMap : ClassMap<RunEvent>
    {
        public RunEventMap()
        {
            Id(x => x.Id);
            References(x => x.Run).Column("RunId");
            References(x => x.Behavior).Column("BehaviorId");
            Map(x => x.Tm);
        }
    }
}