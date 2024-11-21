using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.User.Application.Users.DTOs;
using MoviesAndShowsCatalog.User.Application.Users.UseCases;
using MoviesAndShowsCatalog.User.Domain.Users.Enums;

namespace MoviesAndShowsCatalog.User.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = nameof(Role.Administrator))]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromServices] CreateUser useCase, [FromBody] CreateOrUpdateUserRequest dtoRequest)
    {
        int createdUserId = await useCase.ExecuteAsync(dtoRequest);

        return Created(string.Empty, createdUserId);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetUserResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync([FromServices] GetAllUsers useCase)
    {
        IEnumerable<GetUserResponse> usersResponse = await useCase.ExecuteAsync();

        return Ok(usersResponse);
    }

    [HttpPut("{userId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAsync([FromServices] UpdateUser useCase, [FromRoute] int userId, [FromBody] CreateOrUpdateUserRequest dtoRequest)
    {
        if (userId != dtoRequest.Id)
        {
            return BadRequest("Action not allowed (information conflict).");
        }

        await useCase.ExecuteAsync(dtoRequest);
        
        return NoContent();
    }

    [HttpDelete("{userId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAsync([FromServices] DeleteUser useCase, [FromRoute] int userId)
    {
        await useCase.ExecuteAsync(userId);
        
        return NoContent();
    }
}
