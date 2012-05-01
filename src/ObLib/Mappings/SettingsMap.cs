namespace ObLib.Domain
{
    public class SettingsMap : ActiveRecordBaseMap<Settings>
    {
        public SettingsMap()
        {
            Map(x => x.Name);
            Map(x => x.Value);
        }
    }
}