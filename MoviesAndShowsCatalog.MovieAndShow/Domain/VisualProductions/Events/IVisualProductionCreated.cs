using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Events;

public interface IVisualProductionCreated
{
    event Action<VisualProduction> OnVisualProductionCreated;
}
