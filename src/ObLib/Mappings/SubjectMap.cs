namespace ObLib.Domain
{
    public class SubjectMap : ActiveRecordBaseMap<Subject>
    {
        public SubjectMap()
        {
            References(x => x.Project).UniqueKey("UQ_Subject_Project_Code");
            References(x => x.SubjectGroup);
            Map(x => x.Code).UniqueKey("UQ_Subject_Project_Code");
            Map(x => x.Strain);
            Map(x => x.Sex);
            Map(x => x.DateOfBirth);
            Map(x => x.Origin);
            Map(x => x.Weight);
            HasMany(x => x.Runs);
        }
    }
}