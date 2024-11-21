using MoviesAndShowsCatalog.User.Domain.Notifications.Entities;

namespace MoviesAndShowsCatalog.User.Application.Notifications.Data;

public interface INotificationRepository
{
    Task<int[]> CreateRangeAsync(List<Notification> notificationList);
    Task<IEnumerable<Notification>> GetByUserId(int userId);
}
