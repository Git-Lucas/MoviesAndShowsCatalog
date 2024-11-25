using MoviesAndShowsCatalog.MovieAndShow.Application.MessageQueue;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.MovieAndShow.Infrastructure.Data.Repositories;
using MoviesAndShowsCatalog.MovieAndShow.Infrastructure.MessageQueue;

namespace MoviesAndShowsCatalog.MovieAndShow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services
            .AddRepositories()
            .AddRabbitMq();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IVisualProductionRepository, VisualProductionEF>();

        return services;
    }

    private static IServiceCollection AddRabbitMq(this IServiceCollection services)
    {
        services
            .AddScoped<ConfigRabbitMQ>()
            .AddScoped<IMessageQueueProducer, RabbitMQProducer>();

        return services;
    }
}
