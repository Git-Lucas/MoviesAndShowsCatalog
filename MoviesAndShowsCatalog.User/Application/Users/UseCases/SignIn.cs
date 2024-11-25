using MoviesAndShowsCatalog.User.Application.Authentication;
using MoviesAndShowsCatalog.User.Application.Users.Data;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class SignIn(IUserRepository repository, TokenService tokenService)
{
    private readonly IUserRepository _repository = repository;
    private readonly TokenService _tokenService = tokenService;

    public async Task<SignInResponse> ExecuteAsync(SignInRequest user)
    {
        Domain.Users.Entities.User userFromDatabase = await _repository.Login(user.Username, user.Password)
            ?? throw new InvalidOperationException("User not found in database.");

        SignInResponse loginResponse = new(
            userFromDatabase.Id,
            userFromDatabase.Username,
            _tokenService.GenerateToken(userFromDatabase));

        return loginResponse;
    }
}

public record SignInRequest(string Username, string Password)
{
}

public record SignInResponse(int Id, string Username, string Token)
{
}

