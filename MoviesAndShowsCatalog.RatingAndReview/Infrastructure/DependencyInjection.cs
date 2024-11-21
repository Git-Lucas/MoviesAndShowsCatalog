using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.Data;
using MoviesAndShowsCatalog.RatingAndReview.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data.Repositories;
using MoviesAndShowsCatalog.RatingAndReview.Infrastructure.RabbitMQ;

namespace MoviesAndShowsCatalog.RatingAndReview.Infrastructure;

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
        services
            .AddScoped<IVisualProductionRepository, VisualProductionEf>()
            .AddScoped<IRatingAndReviewRepository, RatingAndReviewEF>();

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
