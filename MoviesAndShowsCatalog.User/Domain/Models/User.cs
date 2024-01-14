﻿using MoviesAndShowsCatalog.User.Domain.Enums;

namespace MoviesAndShowsCatalog.User.Domain.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required Role Role { get; set; }
}