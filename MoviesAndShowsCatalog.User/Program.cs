using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoviesAndShowsCatalog.User.Application.Services;
using MoviesAndShowsCatalog.User.Application.UseCases;
using MoviesAndShowsCatalog.User.Domain.Notifications.Data;
using MoviesAndShowsCatalog.User.Domain.Notifications.UseCases;
using MoviesAndShowsCatalog.User.Domain.RabbitMQ;
using MoviesAndShowsCatalog.User.Domain.Users.Data;
using MoviesAndShowsCatalog.User.Domain.Users.UseCases;
using MoviesAndShowsCatalog.User.Domain.Util;
using MoviesAndShowsCatalog.User.Domain.Util.Services;
using MoviesAndShowsCatalog.User.Infrastructure.Data;
using MoviesAndShowsCatalog.User.Infrastructure.RabbitMQ;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

ISettings settings = new Settings();
byte[] key = Encoding.ASCII.GetBytes(settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      Array.Empty<string>()
    }
  });
});

string connectionStringMySql = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new Exception("Connection string was not found.");
builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseMySql(connectionStringMySql, ServerVersion.AutoDetect(connectionStringMySql)));

builder.Services
    .AddSingleton<IEventProcessor, EventProcessor>()
    //Repositories
    .AddScoped<IUserRepository, UserData>()
    .AddScoped<INotificationRepository, NotificationRepository>()
    //RabbitMQ
    .AddSingleton<ConfigRabbitMQ>()
    .AddHostedService<RabbitMQSubscriber>()
    //Services or Utils
    .AddScoped<ISettings, Settings>()
    .AddScoped<ITokenService, TokenService>()
    .AddScoped<IBearerTokenUtils, BearerTokenUtils>()
    .AddScoped<ITriggerNotificationsUseCase, TriggerNotificationsUseCase>()
    //UseCases
    .AddScoped<ISetGenrePreferencesUseCase, SetGenrePreferences>()
    .AddScoped<IGetGenrePreferencesUseCase, GetGenrePreferences>()
    .AddScoped<IGetNotificationsUseCase, GetNotifications>();

var app = builder.Build();

IServiceScope scope = app.Services.CreateScope();
DatabaseContext databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
await databaseContext.Database.MigrateAsync();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
