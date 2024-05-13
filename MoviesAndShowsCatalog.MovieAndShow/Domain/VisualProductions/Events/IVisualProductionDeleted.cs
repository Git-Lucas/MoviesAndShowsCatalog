namespace MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Events;

public interface IVisualProductionDeleted
{
    event Action<int> OnVisualProductionDeleted;
}
