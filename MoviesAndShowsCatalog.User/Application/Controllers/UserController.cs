using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.DTOs;
using MoviesAndShowsCatalog.User.Domain.Enums;
using MoviesAndShowsCatalog.User.Domain.Services;

namespace MoviesAndShowsCatalog.User.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserData userData, ITokenService tokenService) : ControllerBase
{
    [HttpPost("signUp")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        LoginRequest loginRequest = new()
        {
            Username = registerRequest.Username,
            Password = registerRequest.Password
        };
        Domain.Models.User? userAlreadyExistsInDatabase = await userData.Login(loginRequest);
        if (userAlreadyExistsInDatabase is not null)
        {
            return BadRequest("The user has already been register.");
        }

        Domain.Models.User user = new()
        {
            Username = registerRequest.Username,
            Password = registerRequest.Password,
            Role = Role.Commom
        };
        int createdUserId = await userData.CreateAsync(user);

        return Ok(createdUserId);
    }

    [HttpPost("signIn")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginRequest user)
    {
        Domain.Models.User? userFromDatabase = await userData.Login(user);

        if (userFromDatabase is null)
        {
            return BadRequest("User not found in database.");
        }

        LoginResponse loginResponse = new()
        {
            Username = userFromDatabase.Username,
            Token = tokenService.GenerateToken(userFromDatabase)
        };

        return Ok(loginResponse);
    }
}
