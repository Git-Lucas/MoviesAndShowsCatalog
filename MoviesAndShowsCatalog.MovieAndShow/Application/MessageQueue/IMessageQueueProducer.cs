namespace MoviesAndShowsCatalog.MovieAndShow.Application.MessageQueue;

public interface IMessageQueueProducer
{
    Task SendMessage<T>(T message, string routingKey);
}
