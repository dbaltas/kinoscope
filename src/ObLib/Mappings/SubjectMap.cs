using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class SubjectMap : ClassMap<Subject>
    {
        public SubjectMap()
        {
            Id(x => x.Id);
            References(x => x.Project).Column("ProjectId");
            References(x => x.SubjectGroup).Column("SubjectGroupId");
            Map(x => x.Code);
            Map(x => x.Strain);
            Map(x => x.Sex);
            Map(x => x.DateOfBirth);
            Map(x => x.Origin);
            Map(x => x.Weight);
            Map(x => x.Tm);
        }
    }
}