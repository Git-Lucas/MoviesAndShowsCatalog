using System.ComponentModel.DataAnnotations;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.Models;

public class RatingAndReview
{
    public int Id { get; set; }
    [Range(0, 5, ErrorMessage = $"The {nameof(Rating)} must be between 0 and 5")]
    public float Rating { get; set; }
    public string Review { get; set; } = string.Empty;
    public int VisualProductionId { get; set; }
    public VisualProduction? VisualProduction { get; set; }
}
