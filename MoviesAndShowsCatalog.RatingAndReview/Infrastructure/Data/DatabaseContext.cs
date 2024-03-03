using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Entities;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<VisualProduction> VisualProductions { get; set; }
    public DbSet<Domain.Entities.RatingAndReview> RatingsAndReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.RatingAndReview>()
            .OwnsOne(x => x.Rating)
            .Property(x => x.Value).HasColumnName("Rating");
    }
}
