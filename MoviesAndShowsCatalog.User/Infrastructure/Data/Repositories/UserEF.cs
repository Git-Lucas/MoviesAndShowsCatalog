using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.User.Application.Users.Data;
using MoviesAndShowsCatalog.User.Domain.VisualProductions.Enums;

namespace MoviesAndShowsCatalog.User.Infrastructure.Data.Repositories;

internal class UserEF(DatabaseContext context) : IUserRepository
{
    public async Task<int> CreateAsync(Domain.Users.Entities.User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<IEnumerable<Domain.Users.Entities.User>> GetAllAsync()
    {
        return await context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Domain.Users.Entities.User> GetByIdAsync(int userId)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Id == userId)
            ?? throw new KeyNotFoundException("User not found.");
    }

    public async Task<int[]> GetUsersIdsByGenreAsync(Genre genre)
    {
        IEnumerable<Domain.Users.Entities.User> users = await GetAllAsync();

        return users
            .Where(x => x.GenrePreferences.Contains(genre))
            .Select(x => x.Id)
            .ToArray();
    }

    public async Task UpdateAsync(Domain.Users.Entities.User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int idUser)
    {
        Domain.Users.Entities.User user = await context.Users.FirstOrDefaultAsync(x => x.Id == idUser)
            ?? throw new KeyNotFoundException("User not found in database.");

        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }

    public async Task<Domain.Users.Entities.User?> Login(string username)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<bool> UsernameExists(string username)
    {
        return await context.Users.AnyAsync(x => x.Username == username);
    }
}
