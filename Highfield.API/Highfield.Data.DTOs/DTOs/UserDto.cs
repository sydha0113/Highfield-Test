namespace Highfield.Data.DTOs.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
        public string FavouriteColour { get; set; } = string.Empty;
    }
}
