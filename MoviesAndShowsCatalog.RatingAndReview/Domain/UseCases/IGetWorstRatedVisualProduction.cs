using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

public interface IGetWorstRatedVisualProduction
{
    GetRatingsAndReviewsResponse Execute();
}
