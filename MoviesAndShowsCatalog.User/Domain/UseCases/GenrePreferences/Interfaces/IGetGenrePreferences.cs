namespace MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.Interfaces;

public interface IGetGenrePreferences
{
    Task<string[]> ExecuteAsync(int userId);
}
