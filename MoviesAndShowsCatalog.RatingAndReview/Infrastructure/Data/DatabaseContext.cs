using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Models;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<VisualProduction> VisualProductions { get; set; }
    public DbSet<Domain.Models.RatingAndReview> RatingsAndReviews { get; set; }
}
