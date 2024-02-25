namespace MoviesAndShowsCatalog.User.Domain.UseCases.SignIn.DTOs;

public record SignInResponse
{
    public required int Id { get; set; }
    public required string Username { get; set; }
    public required string Token { get; set; }
}
