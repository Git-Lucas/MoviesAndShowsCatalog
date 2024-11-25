using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.UseCases;

namespace MoviesAndShowsCatalog.RatingAndReview.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class RatingsAndReviewsController : ControllerBase
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromServices] CreateRatingAndReview useCase, [FromBody] CreateRatingAndReviewRequest createRatingAndReviewDTO)
    {
        await useCase.ExecuteAsync(createRatingAndReviewDTO);
        return Created(string.Empty, string.Empty);
    }

    [HttpGet("{visualProductionId:int}")]
    [ProducesResponseType(typeof(GetRatingsAndReviewsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllByVisualProductionIdAsync([FromServices] GetRatingsAndReviewsByVisualProductionId useCase, [FromRoute] int visualProductionId)
    {
        GetRatingsAndReviewsResponse ratingAndReviewResponse = await useCase.ExecuteAsync(visualProductionId);
        return Ok(ratingAndReviewResponse);
    }

    [HttpGet("bestRated")]
    [ProducesResponseType(typeof(GetRatingsAndReviewsResponse), StatusCodes.Status200OK)]
    public IActionResult GetBestRated([FromServices] GetBestRatedVisualProduction useCase)
    {
        GetRatingsAndReviewsResponse bestRatedVisualProduction = useCase.Execute();
        return Ok(bestRatedVisualProduction);
    }

    [HttpGet("worstRated")]
    [ProducesResponseType(typeof(GetRatingsAndReviewsResponse), StatusCodes.Status200OK)]
    public IActionResult GetWorstRated([FromServices] GetWorstRatedVisualProduction useCase)
    {
        GetRatingsAndReviewsResponse worstRatedVisualProduction = useCase.Execute();
        return Ok(worstRatedVisualProduction);
    }
}
