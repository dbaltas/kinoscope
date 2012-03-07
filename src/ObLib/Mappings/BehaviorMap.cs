namespace ObLib.Domain
{
    public class BehaviorMap : ActiveRecordBaseMap<Behavior>
    {
        public BehaviorMap()
        {
            Map(x => x.Name);
            Map(x => x.Type);
            References(x => x.BehavioralTestType).UniqueKey("UQ_Behavior_BehavioralTestType_DefaultKeyStroke");
            Map(x => x.DefaultKeyStroke).UniqueKey("UQ_Behavior_BehavioralTestType_DefaultKeyStroke");
            HasMany(x => x.ResearcherBehaviorKeyStrokes).Cascade.All();
        }
    }
}