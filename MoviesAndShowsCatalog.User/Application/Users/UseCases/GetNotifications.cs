using MoviesAndShowsCatalog.User.Application.Notifications.Data;
using MoviesAndShowsCatalog.User.Application.Notifications.DTOs;
using MoviesAndShowsCatalog.User.Domain.Notifications.Entities;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class GetNotifications(INotificationRepository repository)
{
    private readonly INotificationRepository _repository = repository;

    public async Task<IEnumerable<NotificationResponse>> ExecuteAsync(int userId)
    {
        IEnumerable<Notification> notificationsUser = await _repository.GetByUserId(userId);

        IEnumerable<NotificationResponse> notificationsResponse = notificationsUser.Select(x => x.ToDto());

        return notificationsResponse;
    }
}

public record NotificationResponse(int Id, string Message)
{
}