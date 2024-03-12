using Highfield.Data.Entities.BaseEntities;

namespace Highfield.Data.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
        public string FavouriteColour { get; set; } = string.Empty;
    }
}
