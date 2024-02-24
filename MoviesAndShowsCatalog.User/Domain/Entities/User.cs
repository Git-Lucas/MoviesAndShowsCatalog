using MoviesAndShowsCatalog.User.Domain.Enums;

namespace MoviesAndShowsCatalog.User.Domain.Models;

public class User
{
    public int Id { get; private set; }
    public string Username { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public Role Role { get; private set; } = Role.Commom;

    public User(string username, string password, Role role)
    {
        Username = username;
        Password = password;
        Role = role;
    }

    public User() {}
}
