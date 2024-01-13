namespace MoviesAndShowsCatalog.User.Domain.Data;

public interface IUserData
{
    Task<int> Create();
}
