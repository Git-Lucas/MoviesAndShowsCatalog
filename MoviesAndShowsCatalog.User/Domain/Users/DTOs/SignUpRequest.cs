namespace MoviesAndShowsCatalog.User.Domain.Users.DTOs;

public class SignUpRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
