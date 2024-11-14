using MoviesAndShowsCatalog.RatingAndReview.Domain.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure.RabbitMQ;

public class RabbitMQSubscriber(ILogger<RabbitMQSubscriber> logger, ConfigRabbitMQ config, IEventProcessor eventProcessor) : BackgroundService
{
    private readonly ILogger<RabbitMQSubscriber> _logger = logger;
    private readonly ConfigRabbitMQ _config = config;
    private readonly IEventProcessor _eventProcessor = eventProcessor;
    private readonly string _exchangeName = "VisualProductionExchange";
    private readonly string _queueName = $"{nameof(RatingAndReview)}Queue";

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        IChannel _channel = await _config.CreateChannelAsync();

        try
        {
            await _channel.ExchangeDeclareAsync(exchange: _exchangeName,
                                                type: ExchangeType.Topic,
                                                durable: true,
                                                autoDelete: false,
                                                arguments: null,
                                                cancellationToken: CancellationToken.None);

            await _channel.QueueDeclareAsync(queue: _queueName,
                                             durable: true,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null,
                                             cancellationToken: CancellationToken.None);

            await _channel.QueueBindAsync(queue: _queueName,
                                          exchange: _exchangeName,
                                          routingKey: "Created",
                                          cancellationToken: CancellationToken.None);

            await _channel.QueueBindAsync(queue: _queueName,
                                          exchange: _exchangeName,
                                          routingKey: "Deleted",
                                          cancellationToken: CancellationToken.None);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Unable to define initial RabbitMQ settings. Error: {ex.Message}", ex);
        }

        AsyncEventingBasicConsumer consumer = new(_channel);
        consumer.ReceivedAsync += async (ModuleHandle, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);

            try
            {
                _eventProcessor.ProcessAsync(ea.RoutingKey, message);
            
                await _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to process the message: '{ReceivedMessage}'. Error: {ErrorMessage}", message, ex.Message);
            }
        };

        await _channel.BasicConsumeAsync(queue: _queueName,
                                         autoAck: false,
                                         consumer: consumer);
    }
}
