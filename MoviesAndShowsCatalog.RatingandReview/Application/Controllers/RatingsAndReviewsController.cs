using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class RatingsAndReviewsController(ICreateRatingAndReview createRatingAndReview, IRatingAndReviewData ratingAndReviewData) : ControllerBase
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync(CreateRatingAndReviewDTO createRatingAndReviewDTO)
    {
        try
        {
            await createRatingAndReview.Execute(createRatingAndReviewDTO);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Domain.Models.RatingAndReview>), StatusCodes.Status200OK)]
    public IActionResult GetAllAsync()
    {
        IEnumerable<Domain.Models.RatingAndReview> ratingsAndReviews = ratingAndReviewData.GetAllAsync();
        return Ok(ratingsAndReviews);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await ratingAndReviewData.DeleteAsync(id);
        return NoContent();
    }
}
