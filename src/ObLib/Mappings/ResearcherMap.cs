using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class ResearcherMap : ClassMap<Researcher>
    {
        public ResearcherMap()
        {
            Id(x => x.Id);
            Map(x => x.Username);
            Map(x => x.Password);
            Map(x => x.Tm);
            HasMany(x => x.Projects).KeyColumn("ResearcherId")
                .Cascade.All();			
        }
    }
}