namespace MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Events;

public interface IVisualProductionDeleted
{
    event Action<int> OnVisualProductionDeleted;
}
