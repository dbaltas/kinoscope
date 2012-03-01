using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class RunEventMap : ClassMap<RunEvent>
    {
        public RunEventMap()
        {
            Id(x => x.Id);
            References(x => x.Run);
            References(x => x.Behavior);
            Map(x => x.Tm);
            Map(x => x.TimeTracked);
        }
    }
}