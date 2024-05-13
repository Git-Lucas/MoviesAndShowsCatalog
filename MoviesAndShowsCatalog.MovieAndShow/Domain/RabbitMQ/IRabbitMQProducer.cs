namespace MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;

public interface IRabbitMQProducer
{
    void SendMessage<T>(T message, string routingKey);
}
