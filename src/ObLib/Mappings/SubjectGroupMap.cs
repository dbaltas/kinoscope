using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class SubjectGroupMap : ClassMap<SubjectGroup>
    {
        public SubjectGroupMap()
        {
            Id(x => x.Id);
            References(x => x.Project).Column("ProjectId");
            Map(x => x.Name);
            Map(x => x.Tm);
        }
    }
}