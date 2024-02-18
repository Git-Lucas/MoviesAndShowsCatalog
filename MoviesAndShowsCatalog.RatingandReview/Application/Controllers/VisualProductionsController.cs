using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Models;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.Controllers;

[ApiController]
[Route("visualProductions")]
public class VisualProductionsController(IVisualProductionData visualProductionData) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<VisualProduction>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        List<VisualProduction> visualProductions = await visualProductionData.GetAllAsync();
        return Ok(visualProductions);
    }
}
