using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.UseCases;

public class GetRatingsAndReviewsByVisualProductionId(
    IRatingAndReviewData ratingAndReviewData, 
    IVisualProductionData visualProductionData) : IGetRatingsAndReviewsByVisualProductionId
{
    public async Task<IEnumerable<Domain.Models.RatingAndReview>> ExecuteAsync(int visualProductionId)
    {
        await visualProductionData.GetByIdAsync(visualProductionId);

        IEnumerable<Domain.Models.RatingAndReview> ratingsAndReviews = ratingAndReviewData.GetAllByVisualProductionId(visualProductionId);
        return ratingsAndReviews;
    }
}
