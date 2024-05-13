using RabbitMQ.Client;

namespace MoviesAndShowsCatalog.User.Infrastructure.RabbitMQ;

public class ConfigRabbitMQ
{
    private readonly ConnectionFactory _factory;
    private readonly IConnection? _connection;

    public ConfigRabbitMQ(ILogger<ConfigRabbitMQ> logger, IConfiguration configuration)
    {
        _factory = new ConnectionFactory()
        {
            HostName = configuration["RabbitMQ:Host"],
            Port = int.Parse(configuration["RabbitMQ:Port"]!),
            UserName = configuration["RabbitMQ:UserName"],
            Password = configuration["RabbitMQ:Password"]
        };

        try
        {
            _connection = _factory.CreateConnection();
        }
        catch (Exception ex)
        {
            logger.LogError($"Unable to create connection. MessageError: {ex.Message}");
        }
    }

    public IModel CreateModel()
    {
        return _connection!.CreateModel();
    }
}