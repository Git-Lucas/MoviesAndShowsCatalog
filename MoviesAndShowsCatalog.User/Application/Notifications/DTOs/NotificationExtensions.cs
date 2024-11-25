using MoviesAndShowsCatalog.User.Application.Users.UseCases;
using MoviesAndShowsCatalog.User.Domain.Notifications.Entities;

namespace MoviesAndShowsCatalog.User.Application.Notifications.DTOs;

public static class NotificationExtensions
{
    public static NotificationResponse ToDto(this Notification entity)
    {
        return new NotificationResponse(entity.Id, entity.Message);
    }
}
