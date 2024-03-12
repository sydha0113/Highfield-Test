using Highfield.Data.DTOs.DTOs;
using Highfield.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Highfield.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet, Route("userdata")]
        public async Task<IEnumerable<UserDto>> GetUserData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://recruitment.highfieldqualifications.com/api/");

            var response = await client.GetAsync("test");
            response.EnsureSuccessStatusCode();

            List<User>? userEntities = await response.Content.ReadFromJsonAsync<List<User>>();

            if (userEntities != null && userEntities.Any())
            {
                // project each User object to a UserDto object
                IEnumerable<UserDto> userDtos = userEntities.Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Dob = u.Dob,
                    Email = u.Email,
                    FavouriteColour = u.FavouriteColour
                });

                return userDtos;
            }
            else
            {
                throw new Exception();
            }
        }





        //[HttpGet, Route("userdata")]
        //public async Task<IEnumerable<UserDto>> GetUserData(CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var userData = await _externalApiService.GetUserData(cancellationToken);

        //        if (userData != null)
        //        {
        //            return userData;
        //        }
        //        else
        //        {
        //            throw new Exception("");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // _logger.LogError(ex, "Error occurred while fetching user data.");
        //        throw new Exception("");
        //    }
        //}
    }
}
