using MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.Data;

public interface IVisualProductionRepository
{
    Task CreateAsync(VisualProduction visualProduction);
    Task<IEnumerable<VisualProduction>> GetAllAsync(int skip, int take);
    Task<VisualProduction?> GetByIdAsync(int visualProductionId);
    Task DeleteAsync(VisualProduction visualProduction);
    Task<int> CountAsync();
}
