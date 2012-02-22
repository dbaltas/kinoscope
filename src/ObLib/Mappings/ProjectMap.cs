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
            HasMany(x => x.BehavioralTests).KeyColumn("ProjectID")
                            .Cascade.AllDeleteOrphan();
            HasMany(x => x.SubjectGroups).KeyColumn("ProjectID")
                            .Cascade.AllDeleteOrphan();
            HasMany(x => x.Subjects).KeyColumn("ProjectID")
                            .Cascade.AllDeleteOrphan();
        }
    }
}