using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.User.Domain.Enums;

namespace MoviesAndShowsCatalog.User.Infrastructure.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Domain.Entities.User> Users { get; set; }
    public DbSet<Domain.Entities.Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.User>()
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
