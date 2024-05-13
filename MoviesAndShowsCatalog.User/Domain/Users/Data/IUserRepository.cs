using MoviesAndShowsCatalog.User.Domain.Users.DTOs;
using MoviesAndShowsCatalog.User.Domain.VisualProductions.Enums;

namespace MoviesAndShowsCatalog.User.Domain.Users.Data;

public interface IUserRepository
{
    Task<int> CreateAsync(Entities.User user);
    Task<IEnumerable<Entities.User>> GetAllAsync();
    Task<Entities.User> GetByIdAsync(int userId);
    Task<int[]> GetUsersIdsByGenreAsync(Genre genre);
    Task UpdateAsync(Entities.User user);
    Task DeleteAsync(int idUser);

    Task<Entities.User?> Login(SignInRequest user);
}
