﻿namespace MoviesAndShowsCatalog.User.Domain.DTOs;

public class RegisterRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
