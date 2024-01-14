using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.DTOs;
using MoviesAndShowsCatalog.User.Domain.Enums;

namespace MoviesAndShowsCatalog.User.Application.Controllers;

[ApiController]
[Route("users")]
[Authorize(Roles = nameof(Role.Administrator))]
public class UsersController(IUserData userData) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] Domain.Models.User user)
    {
        LoginRequest loginRequest = new()
        {
            Username = user.Username,
            Password = user.Password
        };
        Domain.Models.User? userAlreadyExistsInDatabase = await userData.Login(loginRequest);
        if (userAlreadyExistsInDatabase is not null)
        {
            return BadRequest("The user has already been register.");
        }

        int createdUserId = await userData.CreateAsync(user);

        return Ok(createdUserId);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Domain.Models.User>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await userData.GetAllAsync());
    }

    [HttpPut("{userId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromRoute] int userId, [FromBody] Domain.Models.User user)
    {
        if (userId != user.Id)
        {
            BadRequest("Action not allowed (information conflict).");
        }

        await userData.UpdateAsync(user);
        return Ok();
    }

    [HttpDelete("{userId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync([FromRoute] int userId)
    {
        await userData.DeleteAsync(userId);
        return Ok();
    }
}
