namespace ObLib.Domain
{
    public class ResearcherBehaviorKeyStrokeMap : ActiveRecordBaseMap<ResearcherBehaviorKeyStroke>
    {
        public ResearcherBehaviorKeyStrokeMap()
        {
            References(x => x.Researcher).UniqueKey("UQ_ResearcherBehaviorKeyStroke_Researcher_Behavior");
            References(x => x.Behavior).UniqueKey("UQ_ResearcherBehaviorKeyStroke_Researcher_Behavior");
            Map(x => x.KeyStroke);
        }
    }
}