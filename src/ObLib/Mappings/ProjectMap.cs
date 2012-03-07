namespace ObLib.Domain
{
    public class ProjectMap : ActiveRecordBaseMap<Project>
    {
        public ProjectMap()
        {
            Map(x => x.Name);
            References(x => x.Researcher);
            HasMany(x => x.BehavioralTests).Cascade.AllDeleteOrphan();
            HasMany(x => x.SubjectGroups).Cascade.AllDeleteOrphan();
            HasMany(x => x.Subjects).Cascade.AllDeleteOrphan();
        }
    }
}