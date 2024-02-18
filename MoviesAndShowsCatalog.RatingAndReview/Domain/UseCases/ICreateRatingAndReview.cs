using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

public interface ICreateRatingAndReview
{
    Task Execute(CreateRatingAndReviewDTO dtoCreateRatingAndReview);
}
