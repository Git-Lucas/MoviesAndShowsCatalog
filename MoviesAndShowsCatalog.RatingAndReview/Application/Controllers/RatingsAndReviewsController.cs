using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class RatingsAndReviewsController(
    ICreateRatingAndReview createRatingAndReview,
    IGetRatingsAndReviewsByVisualProductionId getRatingsAndReviewsByVisualProductionId,
    IGetBestRatedVisualProduction getBestRatedVisualProduction,
    IGetWorstRatedVisualProduction getWorstRatedVisualProduction) : ControllerBase
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync(CreateRatingAndReviewRequest createRatingAndReviewDTO)
    {
        try
        {
            await createRatingAndReview.ExecuteAsync(createRatingAndReviewDTO);
            return Created(string.Empty, string.Empty);
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

    [HttpGet("bestRated")]
    [ProducesResponseType(typeof(GetRatingsAndReviewsResponse), StatusCodes.Status200OK)]
    public IActionResult GetBestRated()
    {
        try
        {
            GetRatingsAndReviewsResponse bestRatedVisualProduction = getBestRatedVisualProduction.Execute();
            return Ok(bestRatedVisualProduction);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("worstRated")]
    [ProducesResponseType(typeof(GetRatingsAndReviewsResponse), StatusCodes.Status200OK)]
    public IActionResult GetWorstRated()
    {
        try
        {
            GetRatingsAndReviewsResponse worstRatedVisualProduction = getWorstRatedVisualProduction.Execute();
            return Ok(worstRatedVisualProduction);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
