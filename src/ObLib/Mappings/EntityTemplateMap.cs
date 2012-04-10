namespace ObLib.Domain
{
    public class EntityTemplateMap : ActiveRecordBaseMap<EntityTemplate>
    {
        public EntityTemplateMap()
        {
            Map(x => x.Name);
            Map(x => x.Entity);
            Map(x => x.Template);
        }
    }
}