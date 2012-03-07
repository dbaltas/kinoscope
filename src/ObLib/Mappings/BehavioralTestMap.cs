namespace ObLib.Domain
{
    public class BehavioralTestMap : ActiveRecordBaseMap<BehavioralTest>
    {
        public BehavioralTestMap()
        {
            References(x => x.Project);
            References(x => x.BehavioralTestType);
            Map(x => x.Name);
            HasMany(x => x.Sessions).Cascade.AllDeleteOrphan();
        }
    }
}