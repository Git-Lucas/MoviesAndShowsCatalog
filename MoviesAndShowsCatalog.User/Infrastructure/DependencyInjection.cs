using MoviesAndShowsCatalog.User.Application.Notifications.Data;
using MoviesAndShowsCatalog.User.Application.Users.Data;
using MoviesAndShowsCatalog.User.Infrastructure.Data.Repositories;
using MoviesAndShowsCatalog.User.Infrastructure.RabbitMQ;

namespace MoviesAndShowsCatalog.User.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrucureServices(this IServiceCollection services)
    {
        services
            .AddRepositories()
            .AddRabbitMq();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IUserRepository, UserEF>()
            .AddScoped<INotificationRepository, NotificationEF>();

        return services;
    }

    private static IServiceCollection AddRabbitMq(this IServiceCollection services)
    {
        services
            .AddSingleton<ConfigRabbitMQ>()
            .AddHostedService<RabbitMQSubscriber>();

        return services;
    }
}
