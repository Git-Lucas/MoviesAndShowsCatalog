using MoviesAndShowsCatalog.User.Domain.Users.DTOs;

namespace MoviesAndShowsCatalog.User.Domain.Users.UseCases;

public interface ISetGenrePreferences
{
    Task ExecuteAsync(SetGenrePreferencesRequest setGenrePreferencesRequest);
}
