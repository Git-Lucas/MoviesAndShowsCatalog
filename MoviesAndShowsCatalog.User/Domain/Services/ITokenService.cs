namespace MoviesAndShowsCatalog.User.Domain.Services;

public interface ITokenService
{
    string GenerateToken(Entities.User user);
}
