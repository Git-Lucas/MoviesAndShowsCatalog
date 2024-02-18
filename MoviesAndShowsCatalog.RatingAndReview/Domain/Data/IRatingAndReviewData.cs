namespace MoviesAndShowsCatalog.RatingAndReview.Domain.Data;

public interface IRatingAndReviewData
{
    Task CreateAsync(Models.RatingAndReview ratingAndReview);
    IEnumerable<Models.RatingAndReview> GetAllByVisualProductionId(int visualProductionId);
    IEnumerable<Models.RatingAndReview> GetAll();
}
