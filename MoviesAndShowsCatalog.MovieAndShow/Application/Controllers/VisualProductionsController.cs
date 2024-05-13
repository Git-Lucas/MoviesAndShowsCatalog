using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Data;
using MoviesAndShowsCatalog.MovieAndShow.Domain.DTOs;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Enums;
using MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.Controllers;

[ApiController]
[Route("visualProductions")]
public class VisualProductionsController(
    IVisualProductionRepository visualProductionRepository, 
    IRabbitMQClient rabbitMQClient) 
    : ControllerBase
{
    private readonly IVisualProductionRepository _visualProductionRepository = visualProductionRepository;
    private readonly IRabbitMQClient _rabbitMQClient = rabbitMQClient;

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [Authorize(Roles = nameof(Role.Administrator))]
    public async Task<IActionResult> CreateAsync([FromBody] CreateVisualProductionRequest createVisualProductionRequest)
    {
        VisualProduction visualProduction = createVisualProductionRequest.ToEntity();

        await _visualProductionRepository.CreateAsync(visualProduction);
        _rabbitMQClient.VisualProductionCreated(visualProduction);

        return Created(string.Empty, visualProduction.Id);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetPagedResponse<VisualProductionResponse>), StatusCodes.Status200OK)]
    [Authorize]
    public async Task<IActionResult> GetAllAsync([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        IEnumerable<VisualProduction> visualProductionsFromDatabase = await _visualProductionRepository.GetAllAsync(skip, take);

        IEnumerable<VisualProductionResponse> visualProductionsResponse = visualProductionsFromDatabase.Select(x => x.ToDto());

        int countVisualProductionInDatabase = await _visualProductionRepository.CountAsync();
        GetPagedResponse<VisualProductionResponse> response = new(countVisualProductionInDatabase,
                                                                  skip,
                                                                  take,
                                                                  visualProductionsResponse);

        return Ok(response);
    }

    [HttpGet("{visualProductionId:int}")]
    [ProducesResponseType(typeof(VisualProduction), StatusCodes.Status200OK)]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int visualProductionId)
    {
        VisualProduction? visualProduction = await _visualProductionRepository.GetByIdAsync(visualProductionId);

        if (visualProduction is null)
        {
            return BadRequest($"The {nameof(VisualProduction)} was not found.");
        }

        return Ok(visualProduction);
    }

    [HttpDelete("{visualProductionId:int}")]
    [Authorize(Roles = nameof(Role.Administrator))]
    public async Task<IActionResult> DeleteAsync([FromRoute] int visualProductionId)
    {
        VisualProduction? visualProduction = await _visualProductionRepository.GetByIdAsync(visualProductionId);

        if (visualProduction is null)
        {
            return BadRequest($"The {nameof(VisualProduction)} was not found.");
        }

        await _visualProductionRepository.DeleteAsync(visualProduction);
        _rabbitMQClient.VisualProductionDeleted(visualProductionId);

        return Ok();
    }
}
