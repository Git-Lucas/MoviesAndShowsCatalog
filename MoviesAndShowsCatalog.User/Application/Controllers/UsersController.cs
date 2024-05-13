using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.User.Domain.Users.Data;
using MoviesAndShowsCatalog.User.Domain.Users.DTOs;
using MoviesAndShowsCatalog.User.Domain.Util.Enums;

namespace MoviesAndShowsCatalog.User.Application.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = nameof(Role.Administrator))]
public class UsersController(IUserRepository userData) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateOrUpdateUserRequest createOrUpdateUserRequest)
    {
        SignInRequest loginRequest = new()
        {
            Username = createOrUpdateUserRequest.Username,
            Password = createOrUpdateUserRequest.Password
        };
        Domain.Users.Entities.User? userAlreadyExistsInDatabase = await userData.Login(loginRequest);
        if (userAlreadyExistsInDatabase is not null)
        {
            return BadRequest("The user has already been register.");
        }

        Domain.Users.Entities.User userEntity = new(
                username: createOrUpdateUserRequest.Username,
                password: createOrUpdateUserRequest.Password,
                role: createOrUpdateUserRequest.Role
            );
        int createdUserId = await userData.CreateAsync(userEntity);

        return Created(string.Empty, createdUserId);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetUserResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<Domain.Users.Entities.User> usersEntitiesFromDatabase = await userData.GetAllAsync();

        List<GetUserResponse> usersResponse = [];
        foreach (Domain.Users.Entities.User user in usersEntitiesFromDatabase)
        {
            usersResponse.Add(
                    new()
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Password = user.Password,
                        Role = user.Role.ToString(),
                        GenrePreferences = user.GenrePreferences.Select(x => x.ToString()).ToArray()
                    }
                );
        }

        return Ok(usersResponse);
    }

    [HttpPut("{userId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAsync([FromRoute] int userId, [FromBody] CreateOrUpdateUserRequest createOrUpdateUserRequest)
    {
        if (userId != createOrUpdateUserRequest.Id)
        {
            BadRequest("Action not allowed (information conflict).");
        }

        Domain.Users.Entities.User userFromDatabase = await userData.GetByIdAsync(userId);
        userFromDatabase.Update(createOrUpdateUserRequest);
        await userData.UpdateAsync(userFromDatabase);
        return NoContent();
    }

    [HttpDelete("{userId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAsync([FromRoute] int userId)
    {
        await userData.DeleteAsync(userId);
        return NoContent();
    }
}
