using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.Enums;
using MoviesAndShowsCatalog.User.Domain.UseCases.SignIn.DTOs;

namespace MoviesAndShowsCatalog.User.Infrastructure.Data;

public class UserData(DatabaseContext context) : IUserData
{
    public async Task<int> CreateAsync(Domain.Entities.User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<IEnumerable<Domain.Entities.User>> GetAllAsync()
    {
        return await context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Domain.Entities.User> GetByIdAsync(int userId)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Id == userId)
            ?? throw new Exception("User not found.");
    }

    public async Task<int[]> GetUsersIdsByGenreAsync(Genre genre)
    {
        IEnumerable<Domain.Entities.User> users = await GetAllAsync();

        return users
            .Where(x => x.GenrePreferences.Contains(genre))
            .Select(x => x.Id)
            .ToArray();
    }
    
    public async Task UpdateAsync(Domain.Entities.User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int idUser)
    {
        Domain.Entities.User user = await context.Users.FirstOrDefaultAsync(x => x.Id == idUser)
            ?? throw new Exception("User not found in database.");

        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }

    public Task<Domain.Entities.User?> Login(SignInRequest user)
    {
        return context.Users.FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == user.Password);
    }
}
