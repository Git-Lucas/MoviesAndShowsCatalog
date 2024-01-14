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

    [HttpDelete("{visualProductionId:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int visualProductionId)
    {
        VisualProduction? visualProduction = await visualProductionData.GetByIdAsync(visualProductionId);

        if (visualProduction is null)
        {
            return BadRequest($"The {nameof(VisualProduction)} was not found.");
        }

        await visualProductionData.DeleteAsync(visualProduction);

        return Ok();
    }
}
