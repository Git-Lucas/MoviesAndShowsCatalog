using MoviesAndShowsCatalog.User.Application.Authentication;
using MoviesAndShowsCatalog.User.Application.Events;
using MoviesAndShowsCatalog.User.Application.Notifications.Services;
using MoviesAndShowsCatalog.User.Application.Users.UseCases;

namespace MoviesAndShowsCatalog.User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddSingleton<EventProcessor>()
            .AddServices()
            .AddUseCases();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<TokenService>()
            .AddScoped<TriggerNotifications>();

        return services;
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services
            .AddScoped<SetGenrePreferences>()
            .AddScoped<GetGenrePreferences>()
            .AddScoped<GetNotifications>()
            .AddScoped<SignIn>()
            .AddScoped<SignUp>()
            .AddScoped<CreateUser>()
            .AddScoped<GetAllUsers>()
            .AddScoped<UpdateUser>()
            .AddScoped<DeleteUser>();

        return services;
    }
}
