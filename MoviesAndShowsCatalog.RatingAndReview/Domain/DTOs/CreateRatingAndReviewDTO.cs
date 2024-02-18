namespace MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;

public record CreateRatingAndReviewDTO
{
    public int Id { get; set; }
    public float Rating { get; set; }
    public string Review { get; set; } = string.Empty;
    public int VisualProductionId { get; set; }
}
