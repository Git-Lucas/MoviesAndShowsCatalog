using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.Entities;

namespace MoviesAndShowsCatalog.User.Infrastructure.Data;

public class NotificationData(DatabaseContext context) : INotificationData
{
    public async Task<int[]> CreateRangeAsync(List<Notification> notificationList)
    {
        await context.Notifications.AddRangeAsync(notificationList);
        await context.SaveChangesAsync();

        return notificationList
            .Select(x => x.Id)
            .ToArray();
    }

    public IEnumerable<Notification> GetByUserId(int userId)
    {
        IEnumerable<Notification> notifications = context.Notifications
            .Where(x => x.UserId == userId);

        return notifications;
    }
}
