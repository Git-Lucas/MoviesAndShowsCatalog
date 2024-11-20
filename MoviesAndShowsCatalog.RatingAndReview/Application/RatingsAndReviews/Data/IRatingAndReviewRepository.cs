namespace MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.Data;

public interface IRatingAndReviewRepository
{
    Task CreateAsync(Domain.RatingsAndReviews.Entities.RatingAndReview ratingAndReview);
    IEnumerable<Domain.RatingsAndReviews.Entities.RatingAndReview> GetAllByVisualProductionId(int visualProductionId);
    IEnumerable<Domain.RatingsAndReviews.Entities.RatingAndReview> GetAll();
}
