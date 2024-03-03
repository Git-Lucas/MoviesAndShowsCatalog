using MoviesAndShowsCatalog.User.Domain.Entities;

namespace MoviesAndShowsCatalog.User.Domain.Services;

public interface INotificationService
{
    Task TriggerNotificationsAsync(VisualProduction visualProduction);
}
