using MoviesAndShowsCatalog.User.Application.Users.Data;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class GetGenrePreferences(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task<string[]> ExecuteAsync(int userId)
    {
        Domain.Users.Entities.User userFromDatabase = await _repository.GetByIdAsync(userId);

        string[] genrePreferencesUser = userFromDatabase
            .GenrePreferences
            .Select(x => x.ToString())
            .ToArray();

        return genrePreferencesUser;
    }
}
