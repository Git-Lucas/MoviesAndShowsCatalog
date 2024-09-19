using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.User.Domain.Notifications.Entities;
using MoviesAndShowsCatalog.User.Domain.VisualProductions.Enums;

namespace MoviesAndShowsCatalog.User.Infrastructure.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Domain.Users.Entities.User> Users { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Users.Entities.User>()
            .Property(x => x.GenrePreferences)
            .HasConversion(
                x => string.Join(",", x),
                x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Enum.Parse<Genre>(x))
                    .Cast<Genre>()
                    .ToList()
                );
    }
}
