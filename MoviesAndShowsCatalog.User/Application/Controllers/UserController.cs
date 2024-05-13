using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.User.Domain.Notifications.DTOs;
using MoviesAndShowsCatalog.User.Domain.Notifications.UseCases;
using MoviesAndShowsCatalog.User.Domain.Users.Data;
using MoviesAndShowsCatalog.User.Domain.Users.DTOs;
using MoviesAndShowsCatalog.User.Domain.Users.UseCases;
using MoviesAndShowsCatalog.User.Domain.Util;
using MoviesAndShowsCatalog.User.Domain.Util.Enums;
using MoviesAndShowsCatalog.User.Domain.Util.Services;

namespace MoviesAndShowsCatalog.User.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(
    IUserRepository userRepository,
    ITokenService tokenService,
    ISetGenrePreferencesUseCase setGenrePreferencesUseCase,
    IGetGenrePreferencesUseCase getGenrePreferencesUseCase,
    IBearerTokenUtils bearerTokenUtils,
    IGetNotificationsUseCase getNotificationsUseCase) 
    : ControllerBase
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ITokenService _tokenService = tokenService;
    private readonly ISetGenrePreferencesUseCase _setGenrePreferencesUseCase = setGenrePreferencesUseCase;
    private readonly IGetGenrePreferencesUseCase _getGenrePreferencesUseCase = getGenrePreferencesUseCase;
    private readonly IBearerTokenUtils _bearerTokenUtils = bearerTokenUtils;
    private readonly IGetNotificationsUseCase _getNotificationsUseCase = getNotificationsUseCase;

    [HttpPost("signUp")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<IActionResult> SignUp(SignUpRequest registerRequest)
    {
        SignInRequest loginRequest = new()
        {
            Username = registerRequest.Username,
            Password = registerRequest.Password
        };
        Domain.Users.Entities.User? userAlreadyExistsInDatabase = await _userRepository.Login(loginRequest);
        if (userAlreadyExistsInDatabase is not null)
        {
            return BadRequest("The user has already been register.");
        }

        Domain.Users.Entities.User user = new(
                username: registerRequest.Username, 
                password: registerRequest.Password, 
                role: Role.Commom
            );
        int createdUserId = await _userRepository.CreateAsync(user);

        return Created(string.Empty, createdUserId);
    }

    [HttpPost("signIn")]
    [ProducesResponseType(typeof(SignInResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SignIn(SignInRequest user)
    {
        Domain.Users.Entities.User? userFromDatabase = await _userRepository.Login(user);

        if (userFromDatabase is null)
        {
            return BadRequest("User not found in database.");
        }

        SignInResponse loginResponse = new()
        {
            Id = userFromDatabase.Id,
            Username = userFromDatabase.Username,
            Token = _tokenService.GenerateToken(userFromDatabase)
        };

        return Ok(loginResponse);
    }

    [HttpGet("notifications")]
    [Authorize]
    [ProducesResponseType(typeof(IEnumerable<NotificationResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetNotificationsAsync()
    {
        int userId;
        try
        {
            string authorizationHeader = HttpContext.Request.Headers.Authorization.ToString();
            string bearerToken = authorizationHeader.Substring("Bearer ".Length).Trim();

            userId = _bearerTokenUtils.GetUserIdByToken(bearerToken);
        }
        catch (Exception)
        {
            return Unauthorized();
        }

        IEnumerable<NotificationResponse> notifications = await _getNotificationsUseCase.ExecuteAsync(userId);

        return Ok(notifications);
    }

    [HttpPost("genrePreferences")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> SetGenrePreferences([FromBody] SetGenrePreferencesRequest setGenrePreferencesRequest)
    {
        int userId;
        try
        {
            string authorizationHeader = HttpContext.Request.Headers.Authorization.ToString();
            string bearerToken = authorizationHeader.Substring("Bearer ".Length).Trim();

            userId = _bearerTokenUtils.GetUserIdByToken(bearerToken);
            setGenrePreferencesRequest.SetUserId(userId);
        }
        catch (Exception)
        {
            return Unauthorized();
        }

        await _setGenrePreferencesUseCase.ExecuteAsync(setGenrePreferencesRequest);
        return NoContent();
    }

    [HttpGet("genrePreferences")]
    [Authorize]
    [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetGenrePreferences()
    {
        int userId;
        try
        {
            string authorizationHeader = HttpContext.Request.Headers.Authorization.ToString();
            string bearerToken = authorizationHeader.Substring("Bearer ".Length).Trim();

            userId = _bearerTokenUtils.GetUserIdByToken(bearerToken);
        }
        catch (Exception)
        {
            return Unauthorized();
        }

        string[] genrePreferencesByUserId = await _getGenrePreferencesUseCase.ExecuteAsync(userId);
        return Ok(genrePreferencesByUserId);
    }
}
