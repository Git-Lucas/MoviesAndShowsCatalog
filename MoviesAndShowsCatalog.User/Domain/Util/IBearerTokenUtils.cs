namespace MoviesAndShowsCatalog.User.Domain.Util;

public interface IBearerTokenUtils
{
    int GetUserIdByToken(string bearerToken);
}
