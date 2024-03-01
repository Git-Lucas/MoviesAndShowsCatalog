using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.Interfaces;

namespace MoviesAndShowsCatalog.User.Application.UseCases;

public class GetGenrePreferences(IUserData userData) : IGetGenrePreferences
{
    public async Task<string[]> ExecuteAsync(int userId)
    {
        Domain.Entities.User userFromDatabase = await userData.GetByIdAsync(userId);

        string[] genrePreferencesUser = userFromDatabase
            .GenrePreferences
            .Select(x => x.ToString())
            .ToArray();

        return genrePreferencesUser;
    }
}
