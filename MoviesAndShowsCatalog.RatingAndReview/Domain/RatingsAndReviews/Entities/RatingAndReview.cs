using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.ValueObjects;
using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.Entities;

public class RatingAndReview
{
    public int Id { get; private set; }
    public Rating Rating { get; private set; } = new();
    public string Review { get; private set; } = string.Empty;
    public int VisualProductionId { get; private set; }
    public VisualProduction? VisualProduction { get; private set; }

    public RatingAndReview() { }

    public RatingAndReview(int id, float rating, string review, int visualProductionId)
    {
        Id = id;
        Rating = new Rating(rating);
        Review = review;
        VisualProductionId = visualProductionId;
    }
}
