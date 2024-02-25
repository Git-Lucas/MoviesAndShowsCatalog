namespace MoviesAndShowsCatalog.User.Domain.UseCases.SignUp.DTOs;

public class SignUpRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
