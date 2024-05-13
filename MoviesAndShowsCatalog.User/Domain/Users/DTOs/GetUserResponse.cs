namespace MoviesAndShowsCatalog.User.Domain.Users.DTOs;

public record GetUserResponse
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }
    public string[] GenrePreferences { get; set; } = [];
}
