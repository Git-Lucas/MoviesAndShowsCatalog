using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

public interface ICreateRatingAndReview
{
    Task ExecuteAsync(CreateRatingAndReviewRequest dtoCreateRatingAndReview);
}
