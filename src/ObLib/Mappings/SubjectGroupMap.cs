using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class SubjectGroupMap : ClassMap<SubjectGroup>
    {
        public SubjectGroupMap()
        {
            Id(x => x.Id);
            References(x => x.Project).Column("ProjectId");
            HasMany(x => x.Subjects).KeyColumn("SubjectGroupId")
                .Cascade.None();
            Map(x => x.Name);
            Map(x => x.Tm);
        }
    }
}