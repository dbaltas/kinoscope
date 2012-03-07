namespace ObLib.Domain
{
    public class TrialMap : ActiveRecordBaseMap<Trial>
    {
        public TrialMap()
        {
            References(x => x.Session);
            Map(x => x.Name);
            Map(x => x.Duration);
            HasMany(x => x.Runs).Cascade.AllDeleteOrphan();
        }
    }
}