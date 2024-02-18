using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

public interface IGetBestRatedVisualProduction
{
    GetRatingsAndReviewsResponse Execute();
}
