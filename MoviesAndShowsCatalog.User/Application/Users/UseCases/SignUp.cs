using MoviesAndShowsCatalog.User.Application.Users.Data;
using MoviesAndShowsCatalog.User.Domain.Users.Enums;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class SignUp(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task<int> ExecuteAsync(SignUpRequest registerRequest)
    {
        Domain.Users.Entities.User? userAlreadyExistsInDatabase = await _repository.Login(registerRequest.Username, registerRequest.Password);
        
        if (userAlreadyExistsInDatabase is not null)
        {
            throw new InvalidOperationException("The user has already been register.");
        }
        
        Domain.Users.Entities.User user = new(
                username: registerRequest.Username,
                password: registerRequest.Password,
                role: Role.Commom
            );
        
        int createdUserId = await _repository.CreateAsync(user);

        return createdUserId;
    }
}

public record SignUpRequest(string Username, string Password)
{
}