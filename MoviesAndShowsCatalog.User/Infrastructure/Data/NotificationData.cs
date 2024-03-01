using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.Entities;

namespace MoviesAndShowsCatalog.User.Infrastructure.Data;

public class NotificationData(DatabaseContext context) : INotificationData
{
    public IEnumerable<Notification> GetByUserId(int userId)
    {
        IEnumerable<Notification> notifications = context.Notifications
            .Where(x => x.UserId == userId);

        return notifications;
    }
}
