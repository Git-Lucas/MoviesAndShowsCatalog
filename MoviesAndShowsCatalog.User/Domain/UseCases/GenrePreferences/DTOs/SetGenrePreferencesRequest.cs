namespace MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.DTOs;

public record SetGenrePreferencesRequest
{
    public required int UserId { get; set; }
    public required int[] GenresCodes { get; set; }
}
