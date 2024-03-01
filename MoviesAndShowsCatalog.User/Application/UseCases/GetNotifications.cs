using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.Entities;
using MoviesAndShowsCatalog.User.Domain.UseCases.Notifications;

namespace MoviesAndShowsCatalog.User.Application.UseCases;

public class GetNotifications(INotificationData notificationsData) : IGetNotifications
{
    public IEnumerable<Notification> Execute(int userId)
    {
        IEnumerable<Notification> notificationsUser = notificationsData.GetByUserId(userId);

        return notificationsUser;
    }
}
