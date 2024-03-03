using MoviesAndShowsCatalog.MovieAndShow.Domain.Enums;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;

public class VisualProduction
{
    public int Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public Genre Genre { get; private set; }
    public int ReleaseYear { get; private set; }

    public VisualProduction(string title, Genre genre, int releaseYear)
    {
        Title = title;
        Genre = genre;
        ReleaseYear = releaseYear;
    }

    public VisualProduction(){ }
}
