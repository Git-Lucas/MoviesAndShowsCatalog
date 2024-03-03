namespace MoviesAndShowsCatalog.User.Domain.RabbitMQ;

public interface IEventProcessor
{
    void ProcessAsync(string routingKey, string message);
}
