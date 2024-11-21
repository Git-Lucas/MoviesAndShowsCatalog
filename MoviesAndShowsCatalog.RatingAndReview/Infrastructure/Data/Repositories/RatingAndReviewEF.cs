using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.Data;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data.Repositories;

internal class RatingAndReviewEF(DatabaseContext context) : IRatingAndReviewRepository
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
