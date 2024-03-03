using MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;

public interface IRabbitMQClient
{
    void VisualProductionCreated(VisualProduction visualProduction);
    void VisualProductionDeleted(int visualProductionId);
}
