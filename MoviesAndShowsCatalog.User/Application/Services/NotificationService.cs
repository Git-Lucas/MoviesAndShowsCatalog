using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.Entities;
using MoviesAndShowsCatalog.User.Domain.Services;

namespace MoviesAndShowsCatalog.User.Application.Services;

public class NotificationService(
    IUserData userData,
    INotificationData notificationData) : INotificationService
{
    public async Task TriggerNotificationsAsync(VisualProduction visualProduction)
    {
        int[] usersIdsToNotification = await userData.GetUsersIdsByGenreAsync(visualProduction.Genre);

        List<Notification> notificationList = [];
        foreach (int userId in usersIdsToNotification)
        {
            notificationList.Add(new(
                    message: $"New {visualProduction.Genre} genre visual production available on the platform: '{visualProduction.Title}'", 
                    userId: userId)
                );
        }

        await notificationData.CreateRangeAsync(notificationList);
    }
}
