using MoviesAndShowsCatalog.User.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.User.Domain.Notifications.UseCases;

public interface ITriggerNotificationsUseCase
{
    Task ExecuteAsync(VisualProduction visualProduction);
}
