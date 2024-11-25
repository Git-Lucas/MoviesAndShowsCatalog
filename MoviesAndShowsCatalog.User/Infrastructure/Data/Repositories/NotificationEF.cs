using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.User.Application.Notifications.Data;
using MoviesAndShowsCatalog.User.Domain.Notifications.Entities;

namespace MoviesAndShowsCatalog.User.Infrastructure.Data.Repositories;

internal class NotificationEF(DatabaseContext context) : INotificationRepository
{
    public async Task<int[]> CreateRangeAsync(List<Notification> notificationList)
    {
        await context.Notifications.AddRangeAsync(notificationList);
        await context.SaveChangesAsync();

        return notificationList
            .Select(x => x.Id)
            .ToArray();
    }

    public async Task<IEnumerable<Notification>> GetByUserId(int userId)
    {
        IEnumerable<Notification> notifications = await context.Notifications
            .Where(x => x.UserId == userId)
            .ToListAsync();

        return notifications;
    }
}
