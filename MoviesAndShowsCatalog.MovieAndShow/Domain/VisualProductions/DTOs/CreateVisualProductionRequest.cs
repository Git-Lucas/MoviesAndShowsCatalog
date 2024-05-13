using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Enums;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.DTOs;

public record CreateVisualProductionRequest
{
    public required string Title { get; set; }
    public required Genre Genre { get; set; }
    public required int ReleaseYear { get; set; }
}
