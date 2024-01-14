using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Models;
using MoviesAndShowsCatalog.RatingAndReview.Domain.RabbitMQ;
using System.Text.Json;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.RabbitMQ;

public class EventProcessor(IServiceScopeFactory serviceScopeFactory, ILogger<EventProcessor> logger) : IEventProcessor
{
    public async Task ProcessAsync(string message)
    {
        using IServiceScope scope = serviceScopeFactory.CreateScope();
        IVisualProductionData visualProductionData = scope.ServiceProvider.GetRequiredService<IVisualProductionData>();

        VisualProduction visualProduction = JsonSerializer.Deserialize<VisualProduction>(message)
            ?? throw new Exception("It was not possible to convert the message.");

        await visualProductionData.CreateAsync(visualProduction);

        logger.LogInformation($"{nameof(VisualProduction)} registered sucessfully.");
    }
}
