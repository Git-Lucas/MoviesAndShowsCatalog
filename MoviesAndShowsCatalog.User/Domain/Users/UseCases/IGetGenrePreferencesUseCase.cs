namespace MoviesAndShowsCatalog.User.Domain.Users.UseCases;

public interface IGetGenrePreferencesUseCase
{
    Task<string[]> ExecuteAsync(int userId);
}
