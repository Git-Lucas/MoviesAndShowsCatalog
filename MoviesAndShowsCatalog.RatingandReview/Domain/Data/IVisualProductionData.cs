using MoviesAndShowsCatalog.RatingAndReview.Domain.Models;

namespace MoviesAndShowsCatalog.RatingAndReview.Domain.Data;

public interface IVisualProductionData
{
    Task CreateAsync(VisualProduction visualProduction);
    Task<List<VisualProduction>> GetAllAsync();
    Task DeleteAsync(VisualProduction visualProduction);
    Task<VisualProduction> GetByIdAsync(int visualProductionId);
}
