using Microsoft.EntityFrameworkCore;

namespace MoviesAndShowsCatalog.User.Infrastructure.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Domain.Models.User> Users { get; set; }
}
