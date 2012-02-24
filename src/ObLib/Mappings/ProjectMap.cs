using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            References(x => x.Researcher).Column("ResearcherId");
            Map(x => x.Tm);
            HasMany(x => x.BehavioralTests).KeyColumn("ProjectId")
                            .Cascade.AllDeleteOrphan();
            HasMany(x => x.SubjectGroups).KeyColumn("ProjectId")
                            .Cascade.AllDeleteOrphan();
            HasMany(x => x.Subjects).KeyColumn("ProjectId")
                            .Cascade.AllDeleteOrphan();
        }
    }
}