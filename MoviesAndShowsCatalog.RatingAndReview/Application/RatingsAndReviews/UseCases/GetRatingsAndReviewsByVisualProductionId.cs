using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.Data;
using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.UseCases;

public class GetRatingsAndReviewsByVisualProductionId(
    IRatingAndReviewRepository ratingAndReviewRepository,
    IVisualProductionRepository visualProductionRepository)
{
    private readonly IRatingAndReviewRepository _ratingAndReviewRepository = ratingAndReviewRepository;
    private readonly IVisualProductionRepository _visualProductionRepository = visualProductionRepository;

    public async Task<GetRatingsAndReviewsResponse> ExecuteAsync(int visualProductionId)
    {
        VisualProduction visualProduction = await _visualProductionRepository.GetByIdAsync(visualProductionId);

        IEnumerable<Domain.RatingsAndReviews.Entities.RatingAndReview> ratingsAndReviews = _ratingAndReviewRepository.GetAllByVisualProductionId(visualProductionId);

        GetRatingsAndReviewsResponse dtoResponse = new(visualProduction.Id, ratingsAndReviews);

        return dtoResponse;
    }
}
