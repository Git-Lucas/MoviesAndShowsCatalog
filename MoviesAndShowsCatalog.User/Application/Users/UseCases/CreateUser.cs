using MoviesAndShowsCatalog.User.Application.Users.Data;
using MoviesAndShowsCatalog.User.Application.Users.DTOs;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class CreateUser(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task<int> ExecuteAsync(CreateOrUpdateUserRequest dtoRequest)
    {
        Domain.Users.Entities.User? userAlreadyExistsInDatabase = await _repository.Login(dtoRequest.Username, dtoRequest.Password);
        if (userAlreadyExistsInDatabase is not null)
        {
            throw new InvalidOperationException("The user has already been register.");
        }

        Domain.Users.Entities.User userEntity = dtoRequest.ToEntity();

        int createdUserId = await _repository.CreateAsync(userEntity);

        return createdUserId;
    }
}
