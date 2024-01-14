using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.RatingAndReview.Application.RabbitMQ;
using MoviesAndShowsCatalog.RatingAndReview.Application.Services;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.RabbitMQ;
using MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHostedService<RabbitMQSubscriber>();

builder.Services
    .AddSingleton<IEventProcessor, EventProcessor>()
    .AddScoped<IVisualProductionData, VisualProductionData>();

var app = builder.Build();

IServiceScope scope = app.Services.CreateScope();
DatabaseContext databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
await databaseContext.Database.MigrateAsync();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
