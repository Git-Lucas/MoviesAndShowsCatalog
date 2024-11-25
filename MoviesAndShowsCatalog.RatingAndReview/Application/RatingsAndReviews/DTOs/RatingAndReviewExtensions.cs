using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.UseCases;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.DTOs;

public static class RatingAndReviewExtensions
{
    public static Domain.RatingsAndReviews.Entities.RatingAndReview ToEntity(this CreateRatingAndReviewRequest dto)
    {
        return new Domain.RatingsAndReviews.Entities.RatingAndReview(
            dto.Id,
            dto.Rating,
            dto.Review,
            dto.VisualProductionId);
    }

    public static RatingAndReviewResponse ToDtoResponse(this Domain.RatingsAndReviews.Entities.RatingAndReview entity)
    {
        return new RatingAndReviewResponse(
            entity.Id,
            entity.Rating.Value,
            entity.Review
        );
    }
}
