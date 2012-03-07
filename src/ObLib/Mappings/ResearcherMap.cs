namespace ObLib.Domain
{
    public class ResearcherMap : ActiveRecordBaseMap<Researcher>
    {
        public ResearcherMap()
        {
            Map(x => x.Username).Unique();
            Map(x => x.Password);
            HasMany(x => x.Projects).Cascade.AllDeleteOrphan();
            HasMany(x => x.ResearcherBehaviorKeyStrokes).Cascade.All();
        }
    }
}