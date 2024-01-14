using MoviesAndShowsCatalog.User.Domain.DTOs;

namespace MoviesAndShowsCatalog.User.Domain.Data;

public interface IUserData
{
    Task<int> CreateAsync(Models.User user);
    Task<List<Models.User>> GetAllAsync();
    Task UpdateAsync(Models.User user);
    Task DeleteAsync(int idUser);

    Task<Models.User?> Login(LoginRequest user);
}
