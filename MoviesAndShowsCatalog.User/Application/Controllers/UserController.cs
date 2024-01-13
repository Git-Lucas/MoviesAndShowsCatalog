using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.DTOs;

namespace MoviesAndShowsCatalog.User.Application.Controllers;

[ApiController]
public class UserController(IUserData userData) : ControllerBase
{
    [HttpPost("signUp")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(Domain.Models.User user)
    {
        LoginRequest loginRequest = new()
        {
            Username = user.Username,
            Password = user.Password
        };
        Domain.Models.User? userAlreadyExistsInDatabase = await userData.GetAsync(loginRequest);

        if (userAlreadyExistsInDatabase is not null)
        {
            return BadRequest("The user has already been register.");
        }
        int createdUserId = await userData.CreateAsync(user);

        return Ok(createdUserId);
    }

    [HttpPost("signIn")]
    [ProducesResponseType(typeof(Domain.Models.User), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginRequest user)
    {
        Domain.Models.User? userFromDatabase = await userData.GetAsync(user);

        if (userFromDatabase is null)
        {
            return BadRequest("User not found in database.");
        }

        return Ok(userFromDatabase);
    }
}
