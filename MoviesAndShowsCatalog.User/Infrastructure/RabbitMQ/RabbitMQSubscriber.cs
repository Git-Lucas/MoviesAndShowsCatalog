using MoviesAndShowsCatalog.User.Domain.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MoviesAndShowsCatalog.User.Infrastructure.RabbitMQ;

public class RabbitMQSubscriber : BackgroundService
{
    private readonly IConfiguration _configuration;
    private readonly IEventProcessor _eventProcessor;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _exchangeName = "VisualProductionExchange1";
    private readonly string _queueName;

    public RabbitMQSubscriber(IConfiguration configuration, IEventProcessor eventProcessor)
    {
        _configuration = configuration;
        _eventProcessor = eventProcessor;

        _connection = new ConnectionFactory()
        {
            HostName = _configuration["RabbitMQ:Host"],
            Port = int.Parse(_configuration["RabbitMQ:Port"]!)
        }.CreateConnection();

        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Topic);
        _queueName = _channel.QueueDeclare().QueueName;

        _channel.QueueBind(
            queue: _queueName,
            exchange: _exchangeName,
            routingKey: "Created");
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
