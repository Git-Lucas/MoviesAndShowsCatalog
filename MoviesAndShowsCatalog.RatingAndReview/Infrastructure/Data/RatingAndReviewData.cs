using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;

public class RatingAndReviewData(DatabaseContext context) : IRatingAndReviewData
{
    public async Task CreateAsync(Domain.Models.RatingAndReview ratingAndReview)
    {
        await context.RatingsAndReviews.AddAsync(ratingAndReview);
        await context.SaveChangesAsync();
    }

    public IEnumerable<Domain.Models.RatingAndReview> GetAllByVisualProductionId(int visualProductionId)
    {
        return context.RatingsAndReviews.Where(x => x.VisualProductionId == visualProductionId);
    }

    public IEnumerable<Domain.Models.RatingAndReview> GetAll()
    {
        return context.RatingsAndReviews;
    }
}
