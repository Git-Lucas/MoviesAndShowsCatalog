using MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.DTOs;

namespace MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.Interfaces;

public interface ISetGenrePreferences
{
    Task ExecuteAsync(SetGenrePreferencesRequest setGenrePreferencesRequest);
}
