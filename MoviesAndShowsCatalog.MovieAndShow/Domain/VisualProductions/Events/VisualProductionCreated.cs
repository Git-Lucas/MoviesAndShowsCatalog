using MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;
using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Events;

public class VisualProductionCreated(IRabbitMQProducer rabbitMQProducer)
{
    private readonly IRabbitMQProducer _rabbitMQProducer = rabbitMQProducer;

    public void OnVisualProductionCreatedPublishOnExchange(VisualProduction visualProduction)
    {
        _rabbitMQProducer.SendMessage(visualProduction, "Created");
    }
}
