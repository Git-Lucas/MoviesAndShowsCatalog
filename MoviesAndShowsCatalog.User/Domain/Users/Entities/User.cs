using MoviesAndShowsCatalog.User.Domain.Users.DTOs;
using MoviesAndShowsCatalog.User.Domain.Util.Enums;
using MoviesAndShowsCatalog.User.Domain.VisualProductions.Enums;

namespace MoviesAndShowsCatalog.User.Domain.Users.Entities;

public class User
{
    public int Id { get; private set; }
    public string Username { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public Role Role { get; private set; } = Role.Commom;
    public List<Genre> GenrePreferences { get; private set; } = [];

    public User(string username, string password, Role role)
    {
        Username = username;
        Password = password;
        Role = role;
    }

    public User() { }

    public void SetGenrePreferences(int[] genreCodes)
    {
        GenrePreferences.Clear();

        foreach (int genreCode in genreCodes)
        {
            if (Enum.IsDefined(typeof(Genre), genreCode))
            {
                GenrePreferences.Add((Genre)genreCode);
            }
        }
    }

    public void Update(CreateOrUpdateUserRequest createOrUpdateUserRequest)
    {
        Username = createOrUpdateUserRequest.Username;
        Password = createOrUpdateUserRequest.Password;
        Role = createOrUpdateUserRequest.Role;
    }
}
