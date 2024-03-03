using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;

public class RatingAndReviewData(DatabaseContext context) : IRatingAndReviewData
{
    public async Task CreateAsync(Domain.Entities.RatingAndReview ratingAndReview)
    {
        await context.RatingsAndReviews.AddAsync(ratingAndReview);
        await context.SaveChangesAsync();
    }

    public IEnumerable<Domain.Entities.RatingAndReview> GetAllByVisualProductionId(int visualProductionId)
    {
        return context.RatingsAndReviews.Where(x => x.VisualProductionId == visualProductionId);
    }

    public IEnumerable<Domain.Entities.RatingAndReview> GetAll()
    {
        return context.RatingsAndReviews;
    }
}
