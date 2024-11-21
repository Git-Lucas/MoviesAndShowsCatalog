using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.MovieAndShow.Application.DTOs;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.DTOs;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.UseCases;
using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;
using MoviesAndShowsCatalog.MovieAndShow.Web.Authentication.Enums;

namespace MoviesAndShowsCatalog.MovieAndShow.Web.Controllers;

[ApiController]
[Route("visualProductions")]
public class VisualProductionsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [Authorize(Roles = nameof(Role.Administrator))]
    public async Task<IActionResult> CreateAsync([FromServices] CreateVisualProduction useCase, [FromBody] CreateVisualProductionRequest dtoRequest)
    {
        int createdId = await useCase.ExecuteAsync(dtoRequest);

        return Created(string.Empty, createdId);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetPagedResponse<VisualProductionResponse>), StatusCodes.Status200OK)]
    [Authorize]
    public async Task<IActionResult> GetAllAsync([FromServices] GetAllVisualProductions useCase, [FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        GetAllVisualProductionsRequest dtoRequest = new(skip, take);

        GetPagedResponse<VisualProductionResponse> response = await useCase.ExecuteAsync(dtoRequest);

        return Ok(response);
    }

    [HttpGet("{visualProductionId:int}")]
    [ProducesResponseType(typeof(VisualProduction), StatusCodes.Status200OK)]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync([FromServices] GetVisualProductionById useCase, [FromRoute] int visualProductionId)
    {
        GetVisualProductionByIdRequest dtoRequest = new(visualProductionId);
        VisualProduction visualProduction = await useCase.ExecuteAsync(dtoRequest);

        return Ok(visualProduction);
    }

    [HttpDelete("{visualProductionId:int}")]
    [Authorize(Roles = nameof(Role.Administrator))]
    public async Task<IActionResult> DeleteAsync([FromServices] DeleteVisualProduction useCase, [FromRoute] int visualProductionId)
    {
        DeleteVisualProductionRequest dtoRequest = new(visualProductionId);
        await useCase.ExecuteAsync(dtoRequest);

        return Ok();
    }
}
