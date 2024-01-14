using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Data;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Enums;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Models;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Util;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.Controllers;

[ApiController]
[Route("visualProductions")]
public class VisualProductionsController(IVisualProductionData visualProductionData) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [Authorize(Roles = nameof(Role.Administrator))]
    public async Task<IActionResult> CreateAsync([FromBody] VisualProduction visualProduction)
    {
        int idCreatedVisualProduction = await visualProductionData.CreateAsync(visualProduction);
        return Ok(idCreatedVisualProduction);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<VisualProduction>), StatusCodes.Status200OK)]
    [Authorize]
    public async Task<IActionResult> GetAllAsync([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        List<VisualProduction> visualProductions = await visualProductionData.GetAllAsync(skip, take);
        int countVisualProductionInDatabase = await visualProductionData.CountAsync();
        int currentPage = Pagination.CurrentPage(skip, take);
        int totalPages = Pagination.TotalPages(countVisualProductionInDatabase, take);
        
        return Ok(new
        {
            count = countVisualProductionInDatabase,
            skip,
            take,
            currentPage,
            totalPages,
            results = visualProductions
        });
    }
}
