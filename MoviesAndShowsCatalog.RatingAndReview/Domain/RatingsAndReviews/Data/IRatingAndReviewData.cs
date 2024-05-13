namespace MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.Data;

public interface IRatingAndReviewData
{
    Task CreateAsync(Entities.RatingAndReview ratingAndReview);
    IEnumerable<Entities.RatingAndReview> GetAllByVisualProductionId(int visualProductionId);
    IEnumerable<Entities.RatingAndReview> GetAll();
}
