using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.RatingAndReview.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.RatingAndReview.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class VisualProductionsController(IVisualProductionRepository visualProductionData) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<VisualProduction>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        List<VisualProduction> visualProductions = await visualProductionData.GetAllAsync();
        return Ok(visualProductions);
    }
}
