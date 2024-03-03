namespace MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.DTOs;

public record SetGenrePreferencesRequest
{
    public int UserId { get; private set; }
    public required int[] GenresCodes { get; set; }

    public void SetUserId(int userId)
    {
        UserId = userId;
    }
}
