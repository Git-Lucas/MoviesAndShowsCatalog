using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Data;

public interface IVisualProductionData
{
    Task CreateAsync(VisualProduction visualProduction);
    Task<List<VisualProduction>> GetAllAsync();
    Task DeleteAsync(VisualProduction visualProduction);
    Task<VisualProduction> GetByIdAsync(int visualProductionId);
}
