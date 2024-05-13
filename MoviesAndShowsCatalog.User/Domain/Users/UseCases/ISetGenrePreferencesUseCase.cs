using MoviesAndShowsCatalog.User.Domain.Users.DTOs;

namespace MoviesAndShowsCatalog.User.Domain.Users.UseCases;

public interface ISetGenrePreferencesUseCase
{
    Task ExecuteAsync(SetGenrePreferencesRequest setGenrePreferencesRequest);
}
