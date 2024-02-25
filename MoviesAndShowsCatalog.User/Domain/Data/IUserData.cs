using MoviesAndShowsCatalog.User.Domain.UseCases.SignIn.DTOs;

namespace MoviesAndShowsCatalog.User.Domain.Data;

public interface IUserData
{
    Task<int> CreateAsync(Models.User user);
    Task<IEnumerable<Models.User>> GetAllAsync();
    Task<Models.User> GetByIdAsync(int userId);
    Task UpdateAsync(Models.User user);
    Task DeleteAsync(int idUser);

    Task<Models.User?> Login(SignInRequest user);
}
