using MoviesAndShowsCatalog.MovieAndShow.Application.MessageQueue;
using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Events;

public class VisualProductionCreated(IMessageQueueProducer rabbitMQProducer)
{
    private readonly IMessageQueueProducer _rabbitMQProducer = rabbitMQProducer;

    public void OnVisualProductionCreatedPublishOnExchange(VisualProduction visualProduction)
    {
        _rabbitMQProducer.SendMessage(visualProduction, "Created");
    }
}
