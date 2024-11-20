using MoviesAndShowsCatalog.RatingAndReview.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Entities;
using System.Text.Json;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.Events;

internal class EventProcessor
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<EventProcessor> _logger;
    private readonly Dictionary<string, Action> _routingKeyActions = [];
    private string _message = string.Empty;

    public EventProcessor(IServiceScopeFactory serviceScopeFactory, ILogger<EventProcessor> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;

        _routingKeyActions.Add($"Created", async () => await CreateVisualProductionAsync(_message));
        _routingKeyActions.Add($"Deleted", async () => await DeleteVisualProductionAsync(_message));
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

    public async Task CreateVisualProductionAsync(string message)
    {
        try
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();
            IVisualProductionRepository visualProductionData = scope.ServiceProvider.GetRequiredService<IVisualProductionRepository>();

            VisualProduction visualProduction = JsonSerializer.Deserialize<VisualProduction>(message)
                ?? throw new JsonException("It was not possible to convert the message.");

            await visualProductionData.CreateAsync(visualProduction);

            _logger.LogInformation("{EntityName} registered sucessfully. (ID: {VisualProductionId} | DateTime: {DateTimeNow})",
                                   nameof(VisualProduction), visualProduction.Id, DateTime.Now);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

    public async Task DeleteVisualProductionAsync(string message)
    {
        try
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();
            IVisualProductionRepository visualProductionData = scope.ServiceProvider.GetRequiredService<IVisualProductionRepository>();

            int visualProductionId = JsonSerializer.Deserialize<int>(message);

            VisualProduction visualProductionFromDatabase = await visualProductionData.GetByIdAsync(visualProductionId);
            await visualProductionData.DeleteAsync(visualProductionFromDatabase);

            _logger.LogInformation("{EntityName} deleted sucessfully. (ID: {VisualProductionId} | DateTime: {DateTimeNow})",
                                   nameof(VisualProduction), visualProductionId, DateTime.Now);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }
}
