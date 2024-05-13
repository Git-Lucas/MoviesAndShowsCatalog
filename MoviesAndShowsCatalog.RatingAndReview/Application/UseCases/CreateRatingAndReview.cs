using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.UseCases;
using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Data;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.UseCases;

public class CreateRatingAndReview(IRatingAndReviewData ratingAndReviewData, IVisualProductionData visualProductionData) : ICreateRatingAndReview
{
    public async Task ExecuteAsync(CreateRatingAndReviewRequest dtoCreateRatingAndReview)
    {
        await visualProductionData.GetByIdAsync(dtoCreateRatingAndReview.VisualProductionId);

        Domain.RatingsAndReviews.Entities.RatingAndReview ratingAndReview = new(
            dtoCreateRatingAndReview.Id,
            dtoCreateRatingAndReview.Rating,
            dtoCreateRatingAndReview.Review,
            dtoCreateRatingAndReview.VisualProductionId);

        await ratingAndReviewData.CreateAsync(ratingAndReview);
    }
}
