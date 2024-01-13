namespace MoviesAndShowsCatalog.User.Domain.Services;

public interface ITokenService
{
    string GenerateToken(Models.User user);
}
