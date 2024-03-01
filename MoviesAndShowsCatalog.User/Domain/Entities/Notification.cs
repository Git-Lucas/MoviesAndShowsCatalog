namespace MoviesAndShowsCatalog.User.Domain.Entities;

public class Notification
{
    public int Id { get; private set; }
    public string Message { get; private set; } = string.Empty;
    public User? User { get; private set; }
    public int UserId { get; private set; }

    public Notification(int id, string message, int userId)
    {
        Id = id;
        Message = message;
        UserId = userId;
    }

    public Notification() { }
}
