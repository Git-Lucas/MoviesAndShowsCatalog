using MoviesAndShowsCatalog.MovieAndShow.Domain.Models;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.Data;

public interface IVisualProductionData
{
    Task<int> CreateAsync(VisualProduction visualProduction);
}
