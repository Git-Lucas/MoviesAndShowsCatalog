using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Models;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<VisualProduction> VisualProductions { get; set; }
}
