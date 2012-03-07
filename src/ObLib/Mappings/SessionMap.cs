namespace ObLib.Domain
{
    public class SessionMap : ActiveRecordBaseMap<Session>
    {
        public SessionMap()
        {
            References(x => x.BehavioralTest);
            Map(x => x.Name);
            HasMany(x => x.Trials).Cascade.AllDeleteOrphan();
        }
    }
}