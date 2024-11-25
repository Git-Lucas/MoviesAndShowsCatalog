using MoviesAndShowsCatalog.User.Application.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MoviesAndShowsCatalog.User.Infrastructure.RabbitMQ;

public class RabbitMQSubscriber(ILogger<RabbitMQSubscriber> logger, ConfigRabbitMQ config, EventProcessor eventProcessor) : BackgroundService
{
    private readonly ILogger<RabbitMQSubscriber> _logger = logger;
    private readonly ConfigRabbitMQ _config = config;
    private readonly EventProcessor _eventProcessor = eventProcessor;
    private readonly string _exchangeName = "VisualProductionExchange";
    private readonly string _queueName = $"{nameof(User)}Queue";

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        IChannel channel;

        try
        {
            channel = await _config.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(exchange: _exchangeName,
                                                type: ExchangeType.Topic,
                                                durable: true,
                                                autoDelete: false,
                                                arguments: null,
                                                cancellationToken: CancellationToken.None);

            await channel.QueueDeclareAsync(queue: _queueName,
                                             durable: true,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null,
                                             cancellationToken: CancellationToken.None);

            await channel.QueueBindAsync(queue: _queueName,
                                          exchange: _exchangeName,
                                          routingKey: "Created",
                                          cancellationToken: CancellationToken.None);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Unable to configure the initial RabbitMQ settings. Error: {ex.Message}", ex);
        }

        AsyncEventingBasicConsumer consumer = new(channel);

        consumer.ReceivedAsync += async (ModuleHandle, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);

            try
            {
                _eventProcessor.ProcessAsync(ea.RoutingKey, message);

                await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to process the message: '{ReceivedMessage}'. Error: {ErrorMessage}", message, ex.Message);
            }
        };

        await channel.BasicConsumeAsync(queue: _queueName,
                                        autoAck: false,
                                        consumer: consumer,
                                        cancellationToken: CancellationToken.None);
    }
}
