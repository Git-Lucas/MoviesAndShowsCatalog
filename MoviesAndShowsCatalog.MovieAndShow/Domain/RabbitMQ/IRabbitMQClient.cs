using MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;

public interface IRabbitMQClient
{
    void CreateVisualProduction(VisualProduction visualProduction);
    void DeleteVisualProduction(int visualProductionId);
}
