using MoviesAndShowsCatalog.RatingAndReview.Application.Events;
using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.UseCases;

namespace MoviesAndShowsCatalog.RatingAndReview.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddSingleton<EventProcessor>()
            .AddUseCases();

        return services;
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services
            .AddScoped<CreateRatingAndReview>()
            .AddScoped<GetRatingsAndReviewsByVisualProductionId>()
            .AddScoped<GetBestRatedVisualProduction>()
            .AddScoped<GetWorstRatedVisualProduction>();

        return services;
    }
}
