using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class SubjectGroupMap : ClassMap<SubjectGroup>
    {
        public SubjectGroupMap()
        {
            Id(x => x.Id);
            References(x => x.Project);
            HasMany(x => x.Subjects).Cascade.None();
            Map(x => x.Name);
            Map(x => x.Tm);
        }
    }
}