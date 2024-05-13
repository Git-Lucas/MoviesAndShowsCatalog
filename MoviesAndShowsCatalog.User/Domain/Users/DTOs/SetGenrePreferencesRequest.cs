namespace MoviesAndShowsCatalog.User.Domain.Users.DTOs;

public record SetGenrePreferencesRequest
{
    public int UserId { get; private set; }
    public required int[] GenresCodes { get; set; }

    public void SetUserId(int userId)
    {
        UserId = userId;
    }
}
