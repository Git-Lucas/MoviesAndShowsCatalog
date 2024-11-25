using MoviesAndShowsCatalog.User.Domain.Users.Enums;

namespace MoviesAndShowsCatalog.User.Application.Users.DTOs;

public record CreateOrUpdateUserRequest(int? Id, string Username, string Password, Role Role)
{
}
