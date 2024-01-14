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
}
