namespace MoviesAndShowsCatalog.User.Domain.Notifications.DTOs;

public record NotificationResponse(int Id, string Message)
{
    public int Id { get; private set; } = Id;
    public string Message { get; private set; } = Message;
}
