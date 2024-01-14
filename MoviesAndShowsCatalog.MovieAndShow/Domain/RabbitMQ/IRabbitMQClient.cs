using MoviesAndShowsCatalog.MovieAndShow.Domain.Models;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;

public interface IRabbitMQClient
{
    void SendVisualProduction(VisualProduction visualProduction);
}
