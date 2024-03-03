using MoviesAndShowsCatalog.User.Domain.UseCases.Notifications.DTOs;

namespace MoviesAndShowsCatalog.User.Domain.UseCases.Notifications.Interfaces;

public interface IGetNotifications
{
    IEnumerable<NotificationResponse> Execute(int userId);
}
