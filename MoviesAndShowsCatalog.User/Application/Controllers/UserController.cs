using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.Enums;
using MoviesAndShowsCatalog.User.Domain.Services;
using MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.DTOs;
using MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.Interfaces;
using MoviesAndShowsCatalog.User.Domain.UseCases.SignIn.DTOs;
using MoviesAndShowsCatalog.User.Domain.UseCases.SignUp.DTOs;

namespace MoviesAndShowsCatalog.User.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(
    IUserData userData, 
    ITokenService tokenService,
    ISetGenrePreferences setGenrePreferences) : ControllerBase
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
        Domain.Models.User? userAlreadyExistsInDatabase = await userData.Login(loginRequest);
        if (userAlreadyExistsInDatabase is not null)
        {
            return BadRequest("The user has already been register.");
        }

        Domain.Models.User user = new(registerRequest.Username, registerRequest.Password, Role.Commom);
        int createdUserId = await userData.CreateAsync(user);

        return Created(string.Empty, createdUserId);
    }

    [HttpPost("signIn")]
    [ProducesResponseType(typeof(SignInResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SignIn(SignInRequest user)
    {
        Domain.Models.User? userFromDatabase = await userData.Login(user);

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

    [HttpPost("genrePreferences")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> SetGenrePreferences([FromBody] SetGenrePreferencesRequest setGenrePreferencesRequest)
    {
        await setGenrePreferences.ExecuteAsync(setGenrePreferencesRequest);
        return NoContent();
    }
}
