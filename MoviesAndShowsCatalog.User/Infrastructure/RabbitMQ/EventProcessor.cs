using MoviesAndShowsCatalog.User.Domain.Entities;
using MoviesAndShowsCatalog.User.Domain.RabbitMQ;
using MoviesAndShowsCatalog.User.Domain.Services;
using System.Text.Json;

namespace MoviesAndShowsCatalog.User.Infrastructure.RabbitMQ;

public class EventProcessor : IEventProcessor
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<EventProcessor> _logger;
    private readonly Dictionary<string, Action> _routingKeyActions = [];
    private string _message = string.Empty;

    public EventProcessor(IServiceScopeFactory serviceScopeFactory, ILogger<EventProcessor> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;

        _routingKeyActions.Add($"Created", async () => await TriggerNotificationsAsync(_message));
    }

    public void ProcessAsync(string routingKey, string message)
    {
        _message = message;

        if (_routingKeyActions.TryGetValue(routingKey, out var action))
        {
            action();
        }
        else
        {
            _logger.LogError($"The message received does not have a mapped function. Routing key: {routingKey}");
        }
    }

    public async Task TriggerNotificationsAsync(string message)
    {
        VisualProduction visualProduction = JsonSerializer.Deserialize<VisualProduction>(message)
            ?? throw new Exception("It was not possible to convert the message.");

        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        INotificationService notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

        await notificationService.TriggerNotificationsAsync(visualProduction);

        _logger.LogInformation($"Triggered notifications for gender '{visualProduction.Genre}'.");
    }
}
