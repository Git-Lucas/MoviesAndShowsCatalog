using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Data;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Models;

namespace MoviesAndShowsCatalog.MovieAndShow.Infrastructure.Data;

public class VisualProductionData(DatabaseContext context) : IVisualProductionData
{
    public async Task<int> CreateAsync(VisualProduction visualProduction)
    {
        await context.VisualProductions.AddAsync(visualProduction);
        await context.SaveChangesAsync();

        return visualProduction.Id;
    }

    public async Task<List<VisualProduction>> GetAllAsync(int skip, int take)
    {
        return await context.VisualProductions
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await context.VisualProductions.CountAsync();
    }
}
