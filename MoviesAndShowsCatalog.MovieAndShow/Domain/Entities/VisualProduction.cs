using MoviesAndShowsCatalog.MovieAndShow.Domain.Enums;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;

public class VisualProduction
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required Genre Genre { get; set; }
    public int ReleaseYear { get; set; }
}
