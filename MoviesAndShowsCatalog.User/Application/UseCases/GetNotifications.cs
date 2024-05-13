using MoviesAndShowsCatalog.User.Domain.Notifications.Data;
using MoviesAndShowsCatalog.User.Domain.Notifications.DTOs;
using MoviesAndShowsCatalog.User.Domain.Notifications.Entities;
using MoviesAndShowsCatalog.User.Domain.Notifications.UseCases;

namespace MoviesAndShowsCatalog.User.Application.UseCases;

public class GetNotifications(INotificationRepository notificationsRepository) : IGetNotificationsUseCase
{
    public async Task<IEnumerable<NotificationResponse>> ExecuteAsync(int userId)
    {
        IEnumerable<Notification> notificationsUser = await notificationsRepository.GetByUserId(userId);

        List<NotificationResponse> notificationsResponse = [];
        foreach(Notification notification in notificationsUser)
        {
            notificationsResponse.Add(new(notification.Id, notification.Message));
        }

        return notificationsResponse;
    }
}
