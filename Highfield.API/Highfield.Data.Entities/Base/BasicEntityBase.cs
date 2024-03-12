namespace Highfield.Data.Entities.BaseEntities
{
    public class BasicEntityBase
    {
        public Guid Id { get; set; }

        public BasicEntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
