﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Domain.Models.User>> GetAllAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task UpdateAsync(Domain.Models.User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int idUser)
    {
        Domain.Models.User user = await context.Users.FirstOrDefaultAsync(x => x.Id == idUser)
            ?? throw new Exception("User not found in database.");

        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }

    public Task<Domain.Models.User?> Login(LoginRequest user)
    {
        return context.Users.FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == user.Password);
    }
}