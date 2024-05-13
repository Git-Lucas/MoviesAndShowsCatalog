namespace MoviesAndShowsCatalog.User.Domain.Users.DTOs;

public record SignInRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
