using MoviesAndShowsCatalog.User.Application.Authentication;
using MoviesAndShowsCatalog.User.Application.Users.Data;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class SignIn(IUserRepository repository, TokenService tokenService)
{
    private readonly IUserRepository _repository = repository;
    private readonly TokenService _tokenService = tokenService;

    public async Task<SignInResponse> ExecuteAsync(SignInRequest user)
    {
        try
        {
            Domain.Users.Entities.User userFromDatabase = await _repository.Login(user.Username)
                ?? throw new InvalidOperationException();

            if (!PasswordHasher.VerifyPassword(userFromDatabase, user.Password))
            {
                throw new InvalidOperationException();
            }

            SignInResponse loginResponse = new(
                userFromDatabase.Id,
                userFromDatabase.Username,
                _tokenService.GenerateToken(userFromDatabase));

            return loginResponse;
        }
        catch (Exception)
        {
            throw new InvalidOperationException("Invalid username or password.");
        }
    }
}

public record SignInRequest(string Username, string Password)
{
}

public record SignInResponse(int Id, string Username, string Token)
{
}

