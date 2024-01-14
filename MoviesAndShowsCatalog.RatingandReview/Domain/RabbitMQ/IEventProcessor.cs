namespace MoviesAndShowsCatalog.RatingAndReview.Domain.RabbitMQ;

public interface IEventProcessor
{
    Task ProcessAsync(string message);
}
