using MoviesAndShowsCatalog.User.Application.Users.UseCases;
using MoviesAndShowsCatalog.User.Domain.Users.Entities;
using MoviesAndShowsCatalog.User.Domain.Users.Enums;

namespace MoviesAndShowsCatalog.User.Application.Users.DTOs;

public static class UserExtensions
{
    public static Domain.Users.Entities.User ToEntity(this CreateOrUpdateUserRequest dto)
    {
        return new Domain.Users.Entities.User(
            username: dto.Username,
            password: dto.Password,
            role: dto.Role);
    }

    public static GetUserResponse ToDto(this Domain.Users.Entities.User entity)
    {
        return new GetUserResponse(
            entity.Id,
            entity.Username,
            entity.Password,
            entity.Role.ToString(),
            entity.GenrePreferences.Select(x => x.ToString()).ToArray());
    }
}
