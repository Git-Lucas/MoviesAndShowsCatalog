using MoviesAndShowsCatalog.MovieAndShow.Application.MessageQueue;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Events;

public class VisualProductionDeleted(IMessageQueueProducer rabbitMQProducer)
{
    private readonly IMessageQueueProducer _rabbitMQProducer = rabbitMQProducer;

    public void OnVisualProductionDeletedPublishOnExchange(int visualProductionId)
    {
        _rabbitMQProducer.SendMessage(visualProductionId, "Deleted");
    }
}
