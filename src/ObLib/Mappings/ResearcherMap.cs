using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class ResearcherMap : ClassMap<Researcher>
    {
        public ResearcherMap()
        {
            Id(x => x.Id);
            Map(x => x.Username).Unique();
            Map(x => x.Password);
            Map(x => x.Tm);
            HasMany(x => x.Projects).Cascade.AllDeleteOrphan();			
        }
    }
}