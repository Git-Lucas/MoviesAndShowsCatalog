using MoviesAndShowsCatalog.User.Domain.Notifications.DTOs;

namespace MoviesAndShowsCatalog.User.Domain.Notifications.UseCases;

public interface IGetNotificationsUseCase
{
    Task<IEnumerable<NotificationResponse>> ExecuteAsync(int userId);
}
