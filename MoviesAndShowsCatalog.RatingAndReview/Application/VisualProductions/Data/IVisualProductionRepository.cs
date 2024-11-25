using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.VisualProductions.Data;

public interface IVisualProductionRepository
{
    Task CreateAsync(VisualProduction visualProduction);
    Task<List<VisualProduction>> GetAllAsync();
    Task DeleteAsync(VisualProduction visualProduction);
    Task<VisualProduction> GetByIdAsync(int visualProductionId);
}
