using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class RatingsAndReviewsController(
    ICreateRatingAndReview createRatingAndReview,
    IGetRatingsAndReviewsByVisualProductionId getRatingsAndReviewsByVisualProductionId) : ControllerBase
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync(CreateRatingAndReviewRequest createRatingAndReviewDTO)
    {
        try
        {
            await createRatingAndReview.ExecuteAsync(createRatingAndReviewDTO);
            return Created(string.Empty, createRatingAndReviewDTO.Id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{visualProductionId:int}")]
    [ProducesResponseType(typeof(GetRatingsAndReviewsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllByVisualProductionIdAsync([FromRoute] int visualProductionId)
    {
        try
        {
            GetRatingsAndReviewsResponse ratingAndReviewResponse = await getRatingsAndReviewsByVisualProductionId.ExecuteAsync(visualProductionId);
            return Ok(ratingAndReviewResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //[HttpDelete("{id:int}")]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    //{
    //    await ratingAndReviewData.DeleteAsync(id);
    //    return NoContent();
    //}
}
