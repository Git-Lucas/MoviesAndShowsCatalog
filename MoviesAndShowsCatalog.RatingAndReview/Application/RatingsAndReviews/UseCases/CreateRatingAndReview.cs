using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.Data;
using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Application.VisualProductions.Data;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.UseCases;

public class CreateRatingAndReview(IRatingAndReviewRepository ratingAndReviewRepository, IVisualProductionRepository visualProductionRepository)
{
    private readonly IRatingAndReviewRepository _ratingAndReviewRepository = ratingAndReviewRepository;
    private readonly IVisualProductionRepository _visualProductionRepository = visualProductionRepository;

    public async Task ExecuteAsync(CreateRatingAndReviewRequest dtoRequest)
    {
        await _visualProductionRepository.GetByIdAsync(dtoRequest.VisualProductionId);

        Domain.RatingsAndReviews.Entities.RatingAndReview entity = dtoRequest.ToEntity();

        await _ratingAndReviewRepository.CreateAsync(entity);
    }
}

public record CreateRatingAndReviewRequest(int Id, float Rating, string Review, int VisualProductionId)
{
}
