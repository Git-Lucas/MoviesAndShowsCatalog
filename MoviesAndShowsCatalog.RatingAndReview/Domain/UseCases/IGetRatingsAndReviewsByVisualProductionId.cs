using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

public interface IGetRatingsAndReviewsByVisualProductionId
{
    Task<GetRatingsAndReviewsResponse> ExecuteAsync(int visualProductionId);
}
