using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Infrastructure.Data;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<VisualProduction> VisualProductions { get; set; }
}
