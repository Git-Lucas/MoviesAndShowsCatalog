﻿using MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;
using MoviesAndShowsCatalog.MovieAndShow.Domain.RabbitMQ;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MoviesAndShowsCatalog.MovieAndShow.Infrastructure.RabbitMQ;

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
        _channel.ExchangeDeclare(
            _exchangeName,
            ExchangeType.Topic,
            true,
            false,
            null);
    }

    public void VisualProductionCreated(VisualProduction visualProduction)
    {
        try
        {
            string message = JsonSerializer.Serialize(visualProduction);
            byte[] body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(
                exchange: _exchangeName,
                routingKey: "Created",
                basicProperties: null,
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
        string message = JsonSerializer.Serialize(visualProductionId);
        byte[] body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(
            exchange: _exchangeName,
            routingKey: "Deleted",
            basicProperties: null,
            body: body);

        _logger.LogInformation($"Message published to the queue. (ID: {visualProductionId} | DateTime: {DateTime.Now})");
    }
}
