using MoviesAndShowsCatalog.User.Domain.Users.Data;
using MoviesAndShowsCatalog.User.Domain.Users.UseCases;

namespace MoviesAndShowsCatalog.User.Application.UseCases;

public class GetGenrePreferences(IUserRepository userData) : IGetGenrePreferencesUseCase
{
    public async Task<string[]> ExecuteAsync(int userId)
    {
        Domain.Users.Entities.User userFromDatabase = await userData.GetByIdAsync(userId);

        string[] genrePreferencesUser = userFromDatabase
            .GenrePreferences
            .Select(x => x.ToString())
            .ToArray();

        return genrePreferencesUser;
    }
}
