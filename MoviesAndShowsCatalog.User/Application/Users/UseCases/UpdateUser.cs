using MoviesAndShowsCatalog.User.Application.Users.Data;
using MoviesAndShowsCatalog.User.Application.Users.DTOs;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class UpdateUser(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task ExecuteAsync(CreateOrUpdateUserRequest dtoRequest)
    {
        Domain.Users.Entities.User userFromDatabase = await _repository.GetByIdAsync((int)dtoRequest.Id!);

        userFromDatabase.Update(
            dtoRequest.Username,
            dtoRequest.Password,
            dtoRequest.Role);
        
        await _repository.UpdateAsync(userFromDatabase);
    }
}
