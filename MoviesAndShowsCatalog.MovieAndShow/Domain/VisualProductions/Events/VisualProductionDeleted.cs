using MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Events;

public class VisualProductionDeleted(IRabbitMQProducer rabbitMQProducer)
{
    private readonly IRabbitMQProducer _rabbitMQProducer = rabbitMQProducer;

    public void OnVisualProductionDeletedPublishOnExchange(int visualProductionId)
    {
        _rabbitMQProducer.SendMessage(visualProductionId, "Deleted");
    }
}
