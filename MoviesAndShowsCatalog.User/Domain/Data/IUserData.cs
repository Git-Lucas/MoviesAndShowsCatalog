using MoviesAndShowsCatalog.User.Domain.DTOs;

namespace MoviesAndShowsCatalog.User.Domain.Data;

public interface IUserData
{
    Task<int> CreateAsync(Models.User user);
    Task<Models.User?> GetAsync(LoginRequest user);
}
