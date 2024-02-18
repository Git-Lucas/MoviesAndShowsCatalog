
namespace MoviesAndShowsCatalog.RatingAndReview.Domain.Data;

public interface IRatingAndReviewData
{
    Task CreateAsync(Models.RatingAndReview ratingAndReview);
    Task DeleteAsync(int id);
    IEnumerable<Models.RatingAndReview> GetAllAsync();
}
