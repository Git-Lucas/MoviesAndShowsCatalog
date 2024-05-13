using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.DTOs;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.UseCases;

public interface IGetRatingsAndReviewsByVisualProductionId
{
    Task<GetRatingsAndReviewsResponse> ExecuteAsync(int visualProductionId);
}
