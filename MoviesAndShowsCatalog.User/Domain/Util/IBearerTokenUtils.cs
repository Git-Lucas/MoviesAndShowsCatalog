namespace MoviesAndShowsCatalog.User.Domain.Util;

public interface IBearerTokenUtils
{
    void ValidateUserIdentity(string bearerToken, int userId);
    int GetUserIdByToken(string bearerToken);
}
