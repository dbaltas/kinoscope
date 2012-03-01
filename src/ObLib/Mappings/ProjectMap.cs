using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            References(x => x.Researcher);
            Map(x => x.Tm);
            HasMany(x => x.BehavioralTests).Cascade.AllDeleteOrphan();
            HasMany(x => x.SubjectGroups).Cascade.AllDeleteOrphan();
            HasMany(x => x.Subjects).Cascade.AllDeleteOrphan();
        }
    }
}