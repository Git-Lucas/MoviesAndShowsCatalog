using MoviesAndShowsCatalog.User.Domain.Entities;

namespace MoviesAndShowsCatalog.User.Domain.Data;

public interface INotificationData
{
    Task<int[]> CreateRangeAsync(List<Notification> notificationList);
    IEnumerable<Notification> GetByUserId(int userId);
}
