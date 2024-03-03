using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.Entities;
using MoviesAndShowsCatalog.User.Domain.UseCases.Notifications.DTOs;
using MoviesAndShowsCatalog.User.Domain.UseCases.Notifications.Interfaces;

namespace MoviesAndShowsCatalog.User.Application.UseCases;

public class GetNotifications(INotificationData notificationsData) : IGetNotifications
{
    public IEnumerable<NotificationResponse> Execute(int userId)
    {
        IEnumerable<Notification> notificationsUser = notificationsData.GetByUserId(userId);

        List<NotificationResponse> notificationsResponse = [];
        foreach(Notification notification in notificationsUser)
        {
            notificationsResponse.Add(new(notification.Id, notification.Message));
        }

        return notificationsResponse;
    }
}
