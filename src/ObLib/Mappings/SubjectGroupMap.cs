namespace ObLib.Domain
{
    public class SubjectGroupMap : ActiveRecordBaseMap<SubjectGroup>
    {
        public SubjectGroupMap()
        {
            References(x => x.Project);
            HasMany(x => x.Subjects).Cascade.None();
            Map(x => x.Name);
        }
    }
}