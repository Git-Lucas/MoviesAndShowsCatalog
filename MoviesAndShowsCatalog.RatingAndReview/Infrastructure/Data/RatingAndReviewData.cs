using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.Data;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;

public class RatingAndReviewData(DatabaseContext context) : IRatingAndReviewData
{
    public async Task CreateAsync(Domain.RatingsAndReviews.Entities.RatingAndReview ratingAndReview)
    {
        await context.RatingsAndReviews.AddAsync(ratingAndReview);
        await context.SaveChangesAsync();
    }

    public IEnumerable<Domain.RatingsAndReviews.Entities.RatingAndReview> GetAllByVisualProductionId(int visualProductionId)
    {
        return context.RatingsAndReviews.Where(x => x.VisualProductionId == visualProductionId);
    }

    public IEnumerable<Domain.RatingsAndReviews.Entities.RatingAndReview> GetAll()
    {
        return context.RatingsAndReviews;
    }
}
