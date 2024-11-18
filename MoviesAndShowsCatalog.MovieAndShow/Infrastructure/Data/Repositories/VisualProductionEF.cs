using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Infrastructure.Data.Repositories;

public class VisualProductionEF(DatabaseContext context) : IVisualProductionRepository
{
    public async Task CreateAsync(VisualProduction visualProduction)
    {
        await context.VisualProductions.AddAsync(visualProduction);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<VisualProduction>> GetAllAsync(int skip, int take)
    {
        return await context.VisualProductions
            .OrderBy(x => x.Id)
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
