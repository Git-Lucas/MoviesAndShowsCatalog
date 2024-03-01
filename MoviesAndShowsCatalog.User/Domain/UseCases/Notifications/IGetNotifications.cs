using MoviesAndShowsCatalog.User.Domain.Entities;

namespace MoviesAndShowsCatalog.User.Domain.UseCases.Notifications;

public interface IGetNotifications
{
    IEnumerable<Notification> Execute(int userId);
}
