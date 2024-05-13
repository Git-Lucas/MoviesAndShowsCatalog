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

    public void SendMessage<T>(T message, string routingKey)
    {
        try
        {
            string json = JsonSerializer.Serialize(message);
            byte[] body = Encoding.UTF8.GetBytes(json);

            IBasicProperties props = _channel.CreateBasicProperties();
            props.Persistent = true;

            _channel.BasicPublish(exchange: _exchangeName,
                                  routingKey: routingKey,
                                  basicProperties: props,
                                  body: body);

            _logger.LogInformation($"Message published to the queue. (Message: {json} | DateTime: {DateTime.Now})");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unable to publish the message on exchange. Error: {ex.Message}");
        }
    }
}
