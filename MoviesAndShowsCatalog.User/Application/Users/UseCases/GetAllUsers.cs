using MoviesAndShowsCatalog.User.Application.Users.Data;
using MoviesAndShowsCatalog.User.Application.Users.DTOs;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class GetAllUsers(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task<IEnumerable<GetUserResponse>> ExecuteAsync()
    {
        IEnumerable<Domain.Users.Entities.User> usersEntitiesFromDatabase = await _repository.GetAllAsync();

        IEnumerable<GetUserResponse> usersResponse = usersEntitiesFromDatabase.Select(x => x.ToDto());

        return usersResponse;
    }
}

public record GetUserResponse(int Id, string Username, string Password, string Role , string[] GenrePreferences)
{
}
