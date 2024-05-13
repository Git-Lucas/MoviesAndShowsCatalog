using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.DTOs;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.UseCases;

public interface ICreateRatingAndReview
{
    Task ExecuteAsync(CreateRatingAndReviewRequest dtoCreateRatingAndReview);
}
