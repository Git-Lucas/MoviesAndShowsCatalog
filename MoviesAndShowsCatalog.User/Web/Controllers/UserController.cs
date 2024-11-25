using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.User.Application.Authentication;
using MoviesAndShowsCatalog.User.Application.Users.UseCases;

namespace MoviesAndShowsCatalog.User.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost("signUp")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<IActionResult> SignUp([FromServices] SignUp useCase, [FromBody] SignUpRequest registerRequest)
    {
        int createdUserId = await useCase.ExecuteAsync(registerRequest);

        return Created(string.Empty, createdUserId);
    }

    [HttpPost("signIn")]
    [ProducesResponseType(typeof(SignInResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SignIn([FromServices] SignIn useCase, [FromBody] SignInRequest user)
    {
        SignInResponse loginResponse = await useCase.ExecuteAsync(user);

        return Ok(loginResponse);
    }

    [HttpGet("notifications")]
    [Authorize]
    [ProducesResponseType(typeof(IEnumerable<NotificationResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetNotificationsAsync([FromServices] GetNotifications useCase)
    {
        int userId;
        try
        {
            string authorizationHeader = HttpContext.Request.Headers.Authorization.ToString();
            string bearerToken = authorizationHeader["Bearer ".Length..].Trim();

            userId = BearerTokenUtils.GetUserIdByToken(bearerToken);
        }
        catch (Exception)
        {
            return Unauthorized();
        }

        IEnumerable<NotificationResponse> notifications = await useCase.ExecuteAsync(userId);

        return Ok(notifications);
    }

    [HttpPost("genrePreferences")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> SetGenrePreferences([FromServices] SetGenrePreferences useCase, [FromBody] SetGenrePreferencesRequest dtoRequest)
    {
        int userId;
        try
        {
            string authorizationHeader = HttpContext.Request.Headers.Authorization.ToString();
            string bearerToken = authorizationHeader["Bearer ".Length..].Trim();

            userId = BearerTokenUtils.GetUserIdByToken(bearerToken);
            if (userId != dtoRequest.UserId)
            {
                return BadRequest("Action not allowed (information conflict).");
            }
        }
        catch (Exception)
        {
            return Unauthorized();
        }

        await useCase.ExecuteAsync(dtoRequest);
        return NoContent();
    }

    [HttpGet("genrePreferences")]
    [Authorize]
    [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetGenrePreferences([FromServices] GetGenrePreferences useCase)
    {
        int userId;
        try
        {
            string authorizationHeader = HttpContext.Request.Headers.Authorization.ToString();
            string bearerToken = authorizationHeader["Bearer ".Length..].Trim();

            userId = BearerTokenUtils.GetUserIdByToken(bearerToken);
        }
        catch (Exception)
        {
            return Unauthorized();
        }

        string[] genrePreferencesByUserId = await useCase.ExecuteAsync(userId);
        return Ok(genrePreferencesByUserId);
    }
}
