namespace MoviesAndShowsCatalog.MovieAndShow.Domain.DTOs;

public record GetPagedResponse<T> where T : class
{
    public required int Count { get; set; }
    public required int Skip { get; set; }
    public required int Take { get; set; }
    public required int CurrentPage { get; set; }
    public required int TotalPages { get; set; }
    public required List<T> Results { get; set; }
}
