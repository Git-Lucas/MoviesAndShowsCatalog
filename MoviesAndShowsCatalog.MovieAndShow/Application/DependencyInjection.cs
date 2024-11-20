using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Events;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.UseCases;

namespace MoviesAndShowsCatalog.MovieAndShow.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddUseCases()
            .AddEvents();

        return services;
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services
            .AddScoped<CreateVisualProduction>()
            .AddScoped<GetAllVisualProductions>()
            .AddScoped<GetVisualProductionById>()
            .AddScoped<DeleteVisualProduction>();

        return services;
    }

    private static IServiceCollection AddEvents(this IServiceCollection services)
    {
        services
            .AddScoped<VisualProductionCreated>()
            .AddScoped<VisualProductionDeleted>();

        return services;
    }
}
