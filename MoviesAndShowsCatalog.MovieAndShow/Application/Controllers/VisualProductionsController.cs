using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Data;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Enums;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Models;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.Controllers;

[ApiController]
[Route("visualProductions")]
public class VisualProductionsController(IVisualProductionData visualProductionData) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [Authorize(Roles = nameof(Role.Administrator))]
    public async Task<IActionResult> CreateVisualProduction([FromBody] VisualProduction visualProduction)
    {
        int idCreatedVisualProduction = await visualProductionData.CreateAsync(visualProduction);
        return Ok(idCreatedVisualProduction);
    }
}
