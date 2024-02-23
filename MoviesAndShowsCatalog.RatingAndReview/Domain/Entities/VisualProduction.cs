using MoviesAndShowsCatalog.RatingAndReview.Domain.Enums;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.Models;

public class VisualProduction
{
    public int Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public Genre Genre { get; private set; }
    public int ReleaseYear { get; private set; }
}
