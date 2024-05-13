namespace MoviesAndShowsCatalog.User.Domain.Users.UseCases;

public interface IGetGenrePreferences
{
    Task<string[]> ExecuteAsync(int userId);
}
