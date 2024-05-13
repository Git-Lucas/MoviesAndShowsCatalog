using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.DTOs;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.UseCases;

public interface IGetWorstRatedVisualProduction
{
    GetRatingsAndReviewsResponse Execute();
}
