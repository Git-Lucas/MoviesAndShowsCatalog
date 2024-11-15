namespace MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;

public interface IRabbitMQProducer
{
    Task SendMessage<T>(T message, string routingKey);
}
