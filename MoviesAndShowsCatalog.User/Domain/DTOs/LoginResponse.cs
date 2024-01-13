namespace MoviesAndShowsCatalog.User.Domain.DTOs;

public record LoginResponse
{
    public required string Username { get; set; }
    public required string Token { get; set; }
}
