using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class RunMap : ClassMap<Run>
    {
        public RunMap()
        {
            Id(x => x.Id);
            References(x => x.Trial).Column("TrialId");
            References(x => x.Subject).Column("SubjectId");
            Map(x => x.Tm);
        }
    }
}