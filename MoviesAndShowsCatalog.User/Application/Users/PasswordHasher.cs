using Microsoft.AspNetCore.Identity;

namespace MoviesAndShowsCatalog.User.Application.Users;

public static class PasswordHasher
{
    private static readonly PasswordHasher<Domain.Users.Entities.User> _passwordHasher = new();

    public static string HashPassword(Domain.Users.Entities.User user)
    {
        return _passwordHasher.HashPassword(user, user.Password);
    }

    public static bool VerifyPassword(Domain.Users.Entities.User user, string providedPassword)
    {
        PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.Password, providedPassword);
        return result == PasswordVerificationResult.Success;
    }
}
