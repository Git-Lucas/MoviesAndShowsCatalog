namespace MoviesAndShowsCatalog.MovieAndShow.Domain.DTOs;

public record VisualProductionResponse
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public int ReleaseYear { get; set; }
}
