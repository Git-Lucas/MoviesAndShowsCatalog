using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.Enums;
using MoviesAndShowsCatalog.User.Domain.Services;
using MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.DTOs;
using MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.Interfaces;
using MoviesAndShowsCatalog.User.Domain.UseCases.Notifications.DTOs;
using MoviesAndShowsCatalog.User.Domain.UseCases.Notifications.Interfaces;
using MoviesAndShowsCatalog.User.Domain.UseCases.SignIn.DTOs;
using MoviesAndShowsCatalog.User.Domain.UseCases.SignUp.DTOs;
using MoviesAndShowsCatalog.User.Domain.Util;

namespace MoviesAndShowsCatalog.User.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(
    IUserData userData,
    ITokenService tokenService,
    ISetGenrePreferences setGenrePreferences,
    IGetGenrePreferences getGenrePreferences,
    IBearerTokenUtils bearerTokenUtils,
    IGetNotifications getNotifications) : ControllerBase
{
    [HttpPost("signUp")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<IActionResult> SignUp(SignUpRequest registerRequest)
    {
        SignInRequest loginRequest = new()
        {
            Username = registerRequest.Username,
            Password = registerRequest.Password
        };
        Domain.Entities.User? userAlreadyExistsInDatabase = await userData.Login(loginRequest);
        if (userAlreadyExistsInDatabase is not null)
        {
            return BadRequest("The user has already been register.");
        }

        Domain.Entities.User user = new(
                username: registerRequest.Username, 
                password: registerRequest.Password, 
                role: Role.Commom
            );
        int createdUserId = await userData.CreateAsync(user);

        return Created(string.Empty, createdUserId);
    }

    [HttpPost("signIn")]
    [ProducesResponseType(typeof(SignInResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SignIn(SignInRequest user)
    {
        Domain.Entities.User? userFromDatabase = await userData.Login(user);

        if (userFromDatabase is null)
        {
            return BadRequest("User not found in database.");
        }

        SignInResponse loginResponse = new()
        {
            Id = userFromDatabase.Id,
            Username = userFromDatabase.Username,
            Token = tokenService.GenerateToken(userFromDatabase)
        };

        return Ok(loginResponse);
    }

    [HttpGet("notifications")]
    [Authorize]
    [ProducesResponseType(typeof(IEnumerable<NotificationResponse>), StatusCodes.Status200OK)]
    public IActionResult GetNotificationsAsync()
    {
        int userId;
        try
        {
            string authorizationHeader = HttpContext.Request.Headers.Authorization.ToString();
            string bearerToken = authorizationHeader.Substring("Bearer ".Length).Trim();

            userId = bearerTokenUtils.GetUserIdByToken(bearerToken);
        }
        catch (Exception)
        {
            return Unauthorized();
        }

        IEnumerable<NotificationResponse> notifications = getNotifications.Execute(userId);

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

            userId = bearerTokenUtils.GetUserIdByToken(bearerToken);
            setGenrePreferencesRequest.SetUserId(userId);
        }
        catch (Exception)
        {
            return Unauthorized();
        }

        await setGenrePreferences.ExecuteAsync(setGenrePreferencesRequest);
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

            userId = bearerTokenUtils.GetUserIdByToken(bearerToken);
        }
        catch (Exception)
        {
            return Unauthorized();
        }

        string[] genrePreferencesByUserId = await getGenrePreferences.ExecuteAsync(userId);
        return Ok(genrePreferencesByUserId);
    }
}
