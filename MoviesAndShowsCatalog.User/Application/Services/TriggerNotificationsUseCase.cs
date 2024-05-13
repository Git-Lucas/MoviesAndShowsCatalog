using MoviesAndShowsCatalog.User.Domain.Notifications.Data;
using MoviesAndShowsCatalog.User.Domain.Notifications.Entities;
using MoviesAndShowsCatalog.User.Domain.Notifications.UseCases;
using MoviesAndShowsCatalog.User.Domain.Users.Data;
using MoviesAndShowsCatalog.User.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.User.Application.Services;

public class TriggerNotificationsUseCase(
    IUserRepository userRepository,
    INotificationRepository notificationRepository) 
    : ITriggerNotificationsUseCase
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
