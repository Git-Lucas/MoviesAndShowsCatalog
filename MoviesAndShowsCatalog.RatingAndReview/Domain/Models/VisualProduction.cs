using MoviesAndShowsCatalog.RatingAndReview.Domain.Enums;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.Models;

public class VisualProduction
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required Genre Genre { get; set; }
    public int ReleaseYear { get; set; }
}
