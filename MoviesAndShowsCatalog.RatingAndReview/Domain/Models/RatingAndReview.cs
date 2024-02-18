namespace MoviesAndShowsCatalog.RatingAndReview.Domain.Models;

public class RatingAndReview
{
    public int Id { get; set; }
    public float Rating { get; set; }
    public string Review { get; set; } = string.Empty;
    public int VisualProductionId { get; set; }
    public VisualProduction? VisualProduction { get; set; }

    public RatingAndReview(int id, float rating, string review, int visualProductionId)
    {
        Id = id;
        Rating = ValidateRating(rating);
        Review = review;
        VisualProductionId = visualProductionId;
    }

    public float ValidateRating(float rating)
    {
        if (rating >= 0 && rating <= 5)
        {
            return rating;
        }

        throw new Exception($"The {nameof(Rating)} must be between 0 and 5.");
    }
}
