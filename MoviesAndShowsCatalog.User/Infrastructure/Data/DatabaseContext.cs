using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.User.Domain.Enums;

namespace MoviesAndShowsCatalog.User.Infrastructure.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Domain.Models.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Models.User>()
            .Property(x => x.GenrePreferences)
            .HasConversion(
                x => string.Join(",", x),
                x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Enum.Parse(typeof(Genre), x))
                    .Cast<Genre>()
                    .ToList()
                );
    }
}
