using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.UseCases;

public class CreateRatingAndReview(IRatingAndReviewData ratingAndReviewData, IVisualProductionData visualProductionData) : ICreateRatingAndReview
{
    public async Task ExecuteAsync(CreateRatingAndReviewRequest dtoCreateRatingAndReview)
    {
        await visualProductionData.GetByIdAsync(dtoCreateRatingAndReview.VisualProductionId);

        Domain.Entities.RatingAndReview ratingAndReview = new(
            dtoCreateRatingAndReview.Id,
            dtoCreateRatingAndReview.Rating,
            dtoCreateRatingAndReview.Review,
            dtoCreateRatingAndReview.VisualProductionId);

        await ratingAndReviewData.CreateAsync(ratingAndReview);
    }
}
