using MoviesAndShowsCatalog.User.Domain.VisualProductions.Enums;
using System.Text.Json.Serialization;

namespace MoviesAndShowsCatalog.User.Domain.VisualProductions.Entities;

public class VisualProduction
{
    [JsonInclude]
    public int Id { get; private set; }

    [JsonInclude]
    public string Title { get; private set; } = string.Empty;

    [JsonInclude]
    public Genre Genre { get; private set; }

    [JsonInclude]
    public int ReleaseYear { get; private set; }
}
