using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Events;

public interface IVisualProductionCreated
{
    event Action<VisualProduction> OnVisualProductionCreated;
}
