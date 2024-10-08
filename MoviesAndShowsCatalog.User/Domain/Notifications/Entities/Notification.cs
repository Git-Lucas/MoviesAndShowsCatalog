﻿namespace MoviesAndShowsCatalog.User.Domain.Notifications.Entities;

public class Notification
{
    public int Id { get; private set; }
    public string Message { get; private set; } = string.Empty;
    public Users.Entities.User? User { get; private set; }
    public int UserId { get; private set; }

    public Notification(string message, int userId)
    {
        Message = message;
        UserId = userId;
    }

    public Notification() { }
}
