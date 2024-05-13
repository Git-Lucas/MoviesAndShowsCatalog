namespace MoviesAndShowsCatalog.User.Domain.Util.Services;

public interface ITokenService
{
    string GenerateToken(Users.Entities.User user);
}
