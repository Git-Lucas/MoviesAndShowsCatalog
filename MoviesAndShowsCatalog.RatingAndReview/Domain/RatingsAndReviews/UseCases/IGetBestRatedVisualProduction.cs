using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.DTOs;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.UseCases;

public interface IGetBestRatedVisualProduction
{
    GetRatingsAndReviewsResponse Execute();
}
