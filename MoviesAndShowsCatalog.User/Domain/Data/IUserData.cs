using MoviesAndShowsCatalog.User.Domain.UseCases.SignIn.DTOs;

namespace MoviesAndShowsCatalog.User.Domain.Data;

public interface IUserData
{
    Task<int> CreateAsync(Entities.User user);
    Task<IEnumerable<Entities.User>> GetAllAsync();
    Task<Entities.User> GetByIdAsync(int userId);
    Task UpdateAsync(Entities.User user);
    Task DeleteAsync(int idUser);

    Task<Entities.User?> Login(SignInRequest user);
}
