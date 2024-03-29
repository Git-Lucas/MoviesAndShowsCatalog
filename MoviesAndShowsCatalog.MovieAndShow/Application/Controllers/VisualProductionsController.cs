﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Data;
using MoviesAndShowsCatalog.MovieAndShow.Domain.DTOs;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Enums;
using MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Util;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.Controllers;

[ApiController]
[Route("visualProductions")]
public class VisualProductionsController(IVisualProductionData visualProductionData, IRabbitMQClient rabbitMQClient) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [Authorize(Roles = nameof(Role.Administrator))]
    public async Task<IActionResult> CreateAsync([FromBody] CreateVisualProductionRequest createVisualProductionRequest)
    {
        VisualProduction visualProduction = new(
                title: createVisualProductionRequest.Title, 
                genre: createVisualProductionRequest.Genre, 
                releaseYear: createVisualProductionRequest.ReleaseYear
            );

        await visualProductionData.CreateAsync(visualProduction);
        rabbitMQClient.VisualProductionCreated(visualProduction);

        return Created(string.Empty, visualProduction.Id);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetPagedResponse<VisualProductionResponse>), StatusCodes.Status200OK)]
    [Authorize]
    public async Task<IActionResult> GetAllAsync([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        IEnumerable<VisualProduction> visualProductionsFromDatabase = await visualProductionData.GetAllAsync(skip, take);
        
        List<VisualProductionResponse> visualProductionsResponse = [];
        foreach (VisualProduction visualProduction in visualProductionsFromDatabase)
        {
            visualProductionsResponse.Add(
                    new()
                    {
                        Id = visualProduction.Id,
                        Title = visualProduction.Title,
                        Genre = visualProduction.Genre.ToString(),
                        ReleaseYear = visualProduction.ReleaseYear
                    }
                );
        }

        int countVisualProductionInDatabase = await visualProductionData.CountAsync();
        GetPagedResponse<VisualProductionResponse> response = new()
        {
            Count = countVisualProductionInDatabase,
            Skip = skip,
            Take = take,
            CurrentPage = Pagination.CurrentPage(skip, take),
            TotalPages = Pagination.TotalPages(countVisualProductionInDatabase, take),
            Results = visualProductionsResponse
        };

        return Ok(response);
    }

    [HttpGet("{visualProductionId:int}")]
    [ProducesResponseType(typeof(VisualProduction), StatusCodes.Status200OK)]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int visualProductionId)
    {
        VisualProduction? visualProduction = await visualProductionData.GetByIdAsync(visualProductionId);

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
        VisualProduction? visualProduction = await visualProductionData.GetByIdAsync(visualProductionId);

        if (visualProduction is null)
        {
            return BadRequest($"The {nameof(VisualProduction)} was not found.");
        }

        await visualProductionData.DeleteAsync(visualProduction);
        rabbitMQClient.VisualProductionDeleted(visualProductionId);

        return Ok();
    }
}
