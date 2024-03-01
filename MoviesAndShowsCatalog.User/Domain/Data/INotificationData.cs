using MoviesAndShowsCatalog.User.Domain.Entities;

namespace MoviesAndShowsCatalog.User.Domain.Data;

public interface INotificationData
{
    IEnumerable<Notification> GetByUserId(int userId);
}
