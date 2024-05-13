using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<VisualProduction> VisualProductions { get; set; }
    public DbSet<Domain.RatingsAndReviews.Entities.RatingAndReview> RatingsAndReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.RatingsAndReviews.Entities.RatingAndReview>()
            .OwnsOne(x => x.Rating)
            .Property(x => x.Value).HasColumnName("Rating");
    }
}
