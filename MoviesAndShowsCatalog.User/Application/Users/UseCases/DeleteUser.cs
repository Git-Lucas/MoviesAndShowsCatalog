using MoviesAndShowsCatalog.User.Application.Users.Data;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class DeleteUser(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task ExecuteAsync(int userId)
    {
        await _repository.DeleteAsync(userId);
    }
}
