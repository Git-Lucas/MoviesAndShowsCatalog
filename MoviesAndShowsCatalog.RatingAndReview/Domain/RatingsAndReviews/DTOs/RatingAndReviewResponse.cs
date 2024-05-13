namespace MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.DTOs;

public record RatingAndReviewResponse
{
    public int Id { get; set; }
    public float Rating { get; set; }
    public string Review { get; set; } = string.Empty;
}
