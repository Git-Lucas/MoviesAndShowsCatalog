using MoviesAndShowsCatalog.User.Application.Authentication;
using MoviesAndShowsCatalog.User.Application.Users.Data;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class SignIn(IUserRepository repository, TokenService tokenService, IHttpContextAccessor httpContextAccessor, ILogger<SignIn> logger)
{
    private readonly IUserRepository _repository = repository;
    private readonly TokenService _tokenService = tokenService;
    private readonly IHttpContextAccessor _httpContextAcessor = httpContextAccessor;
    private readonly ILogger<SignIn> _logger = logger;

    public async Task<SignInResponse> ExecuteAsync(SignInRequest user)
    {
        _logger.LogInformation("SignIn attempt. Username: {Username}, Timestamp: {TimestampUtc}",
            user.Username, DateTime.UtcNow);

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
        catch (Exception ex)
        {
            _logger.LogWarning(ex,
                "Failed SignIn attempt. Username: {Username}, IP: {IpAddress}, Timestamp: {TimestampUtc}",
                user.Username,
                _httpContextAcessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "Unknown",
                DateTime.UtcNow);

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
