using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class BehavioralTestTypeMap : ClassMap<BehavioralTestType>
    {
        public BehavioralTestTypeMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Tm);
        }
    }
}