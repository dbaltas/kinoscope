namespace ObLib.Domain
{
    public class RunMap : ActiveRecordBaseMap<Run>
    {
        public RunMap()
        {
            Map(x => x.TmRun);
            References(x => x.Trial).UniqueKey("UQ_Run_Trial_Subject");
            References(x => x.Subject).UniqueKey("UQ_Run_Trial_Subject");
            HasMany(x => x.RunEvents).Cascade.AllDeleteOrphan();
        }
    }
}