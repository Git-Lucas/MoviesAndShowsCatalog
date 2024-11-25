using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.RatingAndReview.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data.Repositories;

internal class VisualProductionEf(DatabaseContext context) : IVisualProductionRepository
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
            ?? throw new KeyNotFoundException($"{nameof(VisualProduction)} not found in the database.");
    }

    public async Task DeleteAsync(VisualProduction visualProduction)
    {
        context.VisualProductions.Remove(visualProduction);
        await context.SaveChangesAsync();
    }
}
