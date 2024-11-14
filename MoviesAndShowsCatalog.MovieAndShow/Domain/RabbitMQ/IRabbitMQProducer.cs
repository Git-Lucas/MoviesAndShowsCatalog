namespace MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;

public interface IRabbitMQProducer
{
    Task ConnectAsync();
    Task SendMessage<T>(T message, string routingKey);
}
