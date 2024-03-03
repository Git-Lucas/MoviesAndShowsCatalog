using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Data;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Infrastructure.Data;

public class VisualProductionData(DatabaseContext context) : IVisualProductionData
{
    public async Task CreateAsync(VisualProduction visualProduction)
    {
        await context.VisualProductions.AddAsync(visualProduction);
        await context.SaveChangesAsync();
    }

    public async Task<List<VisualProduction>> GetAllAsync(int skip, int take)
    {
        return await context.VisualProductions
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<VisualProduction?> GetByIdAsync(int visualProductionId)
    {
        return await context.VisualProductions.FirstOrDefaultAsync(x => x.Id == visualProductionId);
    }

    public async Task DeleteAsync(VisualProduction visualProduction)
    {
        context.VisualProductions.Remove(visualProduction);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await context.VisualProductions.CountAsync();
    }
}
