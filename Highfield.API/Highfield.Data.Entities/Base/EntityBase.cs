namespace Highfield.Data.Entities.BaseEntities
{
    public class EntityBase : BasicEntityBase
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public EntityBase()
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = DateTime.UtcNow;
        }
    }
}
