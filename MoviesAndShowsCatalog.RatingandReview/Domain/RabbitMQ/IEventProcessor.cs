namespace MoviesAndShowsCatalog.RatingAndReview.Domain.RabbitMQ;

public interface IEventProcessor
{
    void ProcessAsync(string routingKey, string message);
}
