using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace MoviesAndShowsCatalog.User.Infrastructure.RabbitMQ;

public class ConfigRabbitMQ
{
    private readonly ConnectionFactory _factory;

    public ConfigRabbitMQ(IConfiguration configuration)
    {
        _factory = new ConnectionFactory()
        {
            HostName = configuration["RabbitMQ:Host"]!,
            Port = int.Parse(configuration["RabbitMQ:Port"]!),
            UserName = configuration["RabbitMQ:UserName"]!,
            Password = configuration["RabbitMQ:Password"]!
        };
    }

    public async Task<IChannel> CreateChannelAsync()
    {
        try
        {
            IConnection _connection = await _factory.CreateConnectionAsync();
            return await _connection!.CreateChannelAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Unable to create connection. MessageError: {ex.Message}", ex);
        }
    }
}