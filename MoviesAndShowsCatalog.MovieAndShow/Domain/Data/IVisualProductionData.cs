using MoviesAndShowsCatalog.MovieAndShow.Domain.Models;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.Data;

public interface IVisualProductionData
{
    Task<int> CountAsync();
    Task<int> CreateAsync(VisualProduction visualProduction);
    Task<List<VisualProduction>> GetAllAsync(int skip, int take);
}
