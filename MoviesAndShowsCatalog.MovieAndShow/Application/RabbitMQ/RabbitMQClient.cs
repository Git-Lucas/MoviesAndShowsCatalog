using MoviesAndShowsCatalog.MovieAndShow.Domain.Models;
using MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.RabbitMQ;

public class RabbitMQClient : IRabbitMQClient
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<RabbitMQClient> _logger;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _exchangeName = "VisualProductionExchange";

    public RabbitMQClient(IConfiguration configuration, ILogger<RabbitMQClient> logger)
    {
        _configuration = configuration;
        _logger = logger;

        _connection = new ConnectionFactory()
        {
            HostName = _configuration["RabbitMQ:Host"],
            Port = int.Parse(_configuration["RabbitMQ:Port"]!)
        }.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Fanout);
    }

    public void SendVisualProduction(VisualProduction visualProduction)
    {
        string message = JsonSerializer.Serialize(visualProduction);
        byte[] body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(
            exchange: _exchangeName,
            routingKey: "",
            basicProperties: null,
            body: body);

        _logger.LogInformation($"Message published to the queue. (ID: {visualProduction.Id} | DateTime: {DateTime.Now})");
    }
}
