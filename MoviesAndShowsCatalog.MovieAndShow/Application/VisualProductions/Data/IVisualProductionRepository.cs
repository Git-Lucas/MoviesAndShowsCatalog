using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Data;

public interface IVisualProductionRepository
{
    Task CreateAsync(VisualProduction visualProduction);
    Task<IEnumerable<VisualProduction>> GetAllAsync(int skip, int take);
    Task<VisualProduction> GetByIdAsync(int visualProductionId);
    Task DeleteAsync(VisualProduction visualProduction);
    Task<int> CountAsync();
}
