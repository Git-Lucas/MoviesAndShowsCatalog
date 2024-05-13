using MoviesAndShowsCatalog.User.Domain.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MoviesAndShowsCatalog.User.Infrastructure.RabbitMQ;

public class RabbitMQSubscriber : BackgroundService
{
    private readonly ILogger<RabbitMQSubscriber> _logger;
    private readonly IEventProcessor _eventProcessor;
    private readonly IModel _channel;
    private readonly string _exchangeName = "VisualProductionExchange";
    private readonly string? _queueName;

    public RabbitMQSubscriber(ILogger<RabbitMQSubscriber> logger, ConfigRabbitMQ config, IEventProcessor eventProcessor)
    {
        _logger = logger;
        _eventProcessor = eventProcessor;

        _channel = config.CreateModel();

        try
        {
            _channel.ExchangeDeclare(exchange: _exchangeName,
                                     type: ExchangeType.Topic,
                                     durable: true,
                                     autoDelete: false,
                                     arguments: null);
            _queueName = _channel.QueueDeclare().QueueName;

            _channel.QueueBind(
                queue: _queueName,
                exchange: _exchangeName,
                routingKey: "Created");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unable to configure the initial RabbitMQ settings. Error: {ex.Message}");
        }
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        EventingBasicConsumer consumer = new(_channel);

        consumer.Received += (ModuleHandle, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);

            _eventProcessor.ProcessAsync(ea.RoutingKey, message);
        };

        _channel.BasicConsume(
            queue: _queueName,
            autoAck: true,
            consumer: consumer);

        return Task.CompletedTask;
    }
}
