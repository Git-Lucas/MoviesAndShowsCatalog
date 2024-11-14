using MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MoviesAndShowsCatalog.MovieAndShow.Infrastructure.RabbitMQ;

public class RabbitMQProducer(ILogger<RabbitMQProducer> logger, ConfigRabbitMQ config) : IRabbitMQProducer
{
    private readonly ILogger<RabbitMQProducer> _logger = logger;
    private readonly ConfigRabbitMQ _config = config;
    private IChannel? _channel;
    private readonly string _exchangeName = "VisualProductionExchange";

    public async Task ConnectAsync()
    {
        _channel = await _config.CreateChannelAsync();

        try
        {
            await _channel.ExchangeDeclareAsync(exchange: _exchangeName,
                                                type: ExchangeType.Topic,
                                                 durable: true,
                                                 autoDelete: false,
                                                 arguments: null);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Unable to declare exchange. Error: {ex.Message}", ex);
        }
    }

    public async Task SendMessage<T>(T message, string routingKey)
    {
        try
        {
            string json = JsonSerializer.Serialize(message);
            byte[] body = Encoding.UTF8.GetBytes(json);

            BasicProperties props = new()
            {
                Persistent = true,
            };
            props.Persistent = true;

            await _channel!.BasicPublishAsync(exchange: _exchangeName,
                                              routingKey: routingKey,
                                              mandatory: true,
                                              basicProperties: props,
                                              body: body);

            _logger.LogInformation("Message published to the queue. (Message: {Json} | DateTime: {DateTimeNow})", json, DateTime.Now);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unable to publish the message on exchange. Error: {Message}", ex.Message);
        }
    }
}
