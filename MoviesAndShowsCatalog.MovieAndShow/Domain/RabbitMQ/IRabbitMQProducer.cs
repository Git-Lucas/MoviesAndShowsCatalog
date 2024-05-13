using MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;

public interface IRabbitMQProducer
{
    void VisualProductionCreated(VisualProduction visualProduction);
    void VisualProductionDeleted(int visualProductionId);
}
