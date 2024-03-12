using Highfield.Data.DTOs.DTOs;

namespace Highfield.API
{
    public interface IExternalApiService
    {
        Task<IEnumerable<UserDto>> GetUserData(CancellationToken cancellationToken);
    }
}
