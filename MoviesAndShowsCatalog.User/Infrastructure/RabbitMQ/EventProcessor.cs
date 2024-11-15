﻿using MoviesAndShowsCatalog.User.Domain.Notifications.UseCases;
using MoviesAndShowsCatalog.User.Domain.RabbitMQ;
using MoviesAndShowsCatalog.User.Domain.VisualProductions.Entities;
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
            _logger.LogError("The message received does not have a mapped function. Routing key: {RoutingKey}", routingKey);
        }
    }

    public async Task TriggerNotificationsAsync(string message)
    {
        VisualProduction visualProduction = JsonSerializer.Deserialize<VisualProduction>(message)
            ?? throw new JsonException("It was not possible to convert the message.");

        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        ITriggerNotificationsUseCase notificationService = scope.ServiceProvider.GetRequiredService<ITriggerNotificationsUseCase>();

        await notificationService.ExecuteAsync(visualProduction);

        _logger.LogInformation("Triggered notifications for gender '{VisualProductionGenre}'.", visualProduction.Genre);
    }
}
