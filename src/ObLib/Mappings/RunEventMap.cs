namespace ObLib.Domain
{
    public class RunEventMap : ActiveRecordBaseMap<RunEvent>
    {
        public RunEventMap()
        {
            References(x => x.Run);
            References(x => x.Behavior);
            Map(x => x.TimeTracked);
        }
    }
}