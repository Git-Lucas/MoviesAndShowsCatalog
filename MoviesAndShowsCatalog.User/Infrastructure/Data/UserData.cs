using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.DTOs;

namespace MoviesAndShowsCatalog.User.Infrastructure.Data;

public class UserData(DatabaseContext context) : IUserData
{
    public async Task<int> CreateAsync(Domain.Models.User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user.Id;
    }

    public Task<Domain.Models.User?> GetAsync(LoginRequest user)
    {
        return context.Users.FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == user.Password);
    }
}
