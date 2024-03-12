using Highfield.Data.DTOs.DTOs;
using Highfield.Data.Entities;

namespace Highfield.API
{
    public class ExternalApiService : IExternalApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string HIGHFIELD_API_TEST = "HightFieldApiTest";
        private readonly string get_user_details_endpoint = "test";

        public ExternalApiService(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<UserDto>> GetUserData(CancellationToken cancellationToken)
        {
            try
            {
                HttpClient httpClient = this._httpClientFactory!.CreateClient(HIGHFIELD_API_TEST);
                HttpResponseMessage response = await httpClient.GetAsync(get_user_details_endpoint);
                response.EnsureSuccessStatusCode();

                // check if response and content is null
                if (response.Content != null)
                {
                    IEnumerable<User>? userEntities = await response.Content.ReadFromJsonAsync<IEnumerable<User>>();

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
                        // _logger.LogError($"Failed to deserialize user data from Highfield API");
                        return Enumerable.Empty<UserDto>();
                    }
                }
                else
                {
                    // _logger.LogError("Response Content is null while fetching users from Highfield API");
                    return Enumerable.Empty<UserDto>();
                }

            }
            catch (Exception ex)
            {
                // _logger.LogError("Error occured while fetching user data from Highfield API");
                throw; // re-throw the exception for the caller to handle
            }


        }
    }
}
