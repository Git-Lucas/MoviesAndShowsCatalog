namespace MoviesAndShowsCatalog.User.Domain.Util;

public interface IValidateUserIdentity
{
    void ExecuteComparingWithToken(string berarTokne, int userId);
}
