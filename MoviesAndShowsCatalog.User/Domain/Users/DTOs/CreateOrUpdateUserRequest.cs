﻿using MoviesAndShowsCatalog.User.Domain.Util.Enums;

namespace MoviesAndShowsCatalog.User.Domain.Users.DTOs;

public record CreateOrUpdateUserRequest
{
    public int? Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required Role Role { get; set; }
}
