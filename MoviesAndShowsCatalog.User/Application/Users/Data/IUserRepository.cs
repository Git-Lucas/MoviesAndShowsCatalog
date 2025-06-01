using MoviesAndShowsCatalog.User.Domain.VisualProductions.Enums;

namespace MoviesAndShowsCatalog.User.Application.Users.Data;

public interface IUserRepository
{
    Task<int> CreateAsync(Domain.Users.Entities.User user);
    Task<IEnumerable<Domain.Users.Entities.User>> GetAllAsync();
    Task<Domain.Users.Entities.User> GetByIdAsync(int userId);
    Task<int[]> GetUsersIdsByGenreAsync(Genre genre);
    Task UpdateAsync(Domain.Users.Entities.User user);
    Task DeleteAsync(int idUser);

    Task<Domain.Users.Entities.User?> Login(string username);
    Task<bool> UsernameExists(string username);
}
