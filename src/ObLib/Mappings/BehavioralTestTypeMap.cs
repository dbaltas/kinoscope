namespace ObLib.Domain
{
    public class BehavioralTestTypeMap : ActiveRecordBaseMap<BehavioralTestType>
    {
        public BehavioralTestTypeMap()
        {
            Map(x => x.Name);
            Map(x => x.Description);
        }
    }
}