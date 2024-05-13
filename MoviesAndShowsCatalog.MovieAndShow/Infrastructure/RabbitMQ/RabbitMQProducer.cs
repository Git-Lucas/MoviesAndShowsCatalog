using MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;
using MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MoviesAndShowsCatalog.MovieAndShow.Infrastructure.RabbitMQ;

public class RabbitMQProducer : IRabbitMQProducer
{
    private readonly ILogger<RabbitMQProducer> _logger;
    private readonly IModel _channel;
    private readonly string _exchangeName = "VisualProductionExchange";

    public RabbitMQProducer(ILogger<RabbitMQProducer> logger, ConfigRabbitMQ config)
    {
        _logger = logger;

        _channel = config.CreateModel();

        try
        {
            _channel.ExchangeDeclare(exchange: _exchangeName,
                                     type: ExchangeType.Topic,
                                     durable: true,
                                     autoDelete: false,
                                     arguments: null);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unable to declare exchange. Error: {ex.Message}");
        }
    }

    public void VisualProductionCreated(VisualProduction visualProduction)
    {
        try
        {
            string message = JsonSerializer.Serialize(visualProduction);
            byte[] body = Encoding.UTF8.GetBytes(message);

            IBasicProperties props = _channel.CreateBasicProperties();
            props.Persistent = true;

            _channel.BasicPublish(exchange: _exchangeName,
                                  routingKey: "Created",
                                  basicProperties: props,
                                  body: body);

            _logger.LogInformation($"Message published to the queue. (ID: {visualProduction.Id} | DateTime: {DateTime.Now})");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unable to publish the message on exchange. Error: {ex.Message}");
        }
    }

    public void VisualProductionDeleted(int visualProductionId)
    {
        try
        {
            string message = JsonSerializer.Serialize(visualProductionId);
            byte[] body = Encoding.UTF8.GetBytes(message);

            IBasicProperties props = _channel.CreateBasicProperties();
            props.Persistent = true;

            _channel.BasicPublish(exchange: _exchangeName,
                                  routingKey: "Deleted",
                                  basicProperties: props,
                                  body: body);

            _logger.LogInformation($"Message published to the queue. (ID: {visualProductionId} | DateTime: {DateTime.Now})");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unable to publish the message on exchange. Error: {ex.Message}");
        }
    }
}
