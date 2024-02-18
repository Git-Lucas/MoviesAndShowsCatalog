using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;

public class RatingAndReviewData(DatabaseContext context) : IRatingAndReviewData
{
    public async Task CreateAsync(Domain.Models.RatingAndReview ratingAndReview)
    {
        await context.RatingsAndReviews.AddAsync(ratingAndReview);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Domain.Models.RatingAndReview ratingAndReviewFromDatabase = context.RatingsAndReviews.FirstOrDefault(x => x.Id == id)!;
        context.RatingsAndReviews.Remove(ratingAndReviewFromDatabase);
        await context.SaveChangesAsync();
    }

    public IEnumerable<Domain.Models.RatingAndReview> GetAllAsync()
    {
        return context.RatingsAndReviews;
    }
}
