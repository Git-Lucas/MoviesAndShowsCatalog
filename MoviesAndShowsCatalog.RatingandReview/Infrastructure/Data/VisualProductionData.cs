using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Models;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;

public class VisualProductionData(DatabaseContext context) : IVisualProductionData
{
    public async Task CreateAsync(VisualProduction visualProduction)
    {
        await context.VisualProductions.AddAsync(visualProduction);
        await context.SaveChangesAsync();
    }

    public async Task<List<VisualProduction>> GetAllAsync()
    {
        return await context.VisualProductions.ToListAsync();
    }

    public async Task<VisualProduction> GetByIdAsync(int visualProductionId)
    {
        return await context.VisualProductions.FirstOrDefaultAsync(x => x.Id == visualProductionId)
            ?? throw new Exception($"{nameof(VisualProduction)} not found int the database.");
    }

    public async Task DeleteAsync(VisualProduction visualProduction)
    {
        context.VisualProductions.Remove(visualProduction);
        await context.SaveChangesAsync();
    }
}
