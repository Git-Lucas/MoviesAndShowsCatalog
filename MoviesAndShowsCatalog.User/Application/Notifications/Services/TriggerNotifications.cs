using MoviesAndShowsCatalog.User.Application.Notifications.Data;
using MoviesAndShowsCatalog.User.Application.Users.Data;
using MoviesAndShowsCatalog.User.Domain.Notifications.Entities;
using MoviesAndShowsCatalog.User.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.User.Application.Notifications.Services;

public class TriggerNotifications(
    IUserRepository userRepository,
    INotificationRepository notificationRepository)
{
    public async Task ExecuteAsync(VisualProduction visualProduction)
    {
        int[] usersIdsToNotification = await userRepository.GetUsersIdsByGenreAsync(visualProduction.Genre);

        List<Notification> notificationList = [];
        foreach (int userId in usersIdsToNotification)
        {
            notificationList.Add(new(
                    message: $"New {visualProduction.Genre} genre visual production available on the platform: '{visualProduction.Title}'",
                    userId: userId)
                );
        }

        await notificationRepository.CreateRangeAsync(notificationList);
    }
}
