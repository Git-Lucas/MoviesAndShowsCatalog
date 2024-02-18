using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoviesAndShowsCatalog.RatingAndReview.Application.UseCases;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.RabbitMQ;
using MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Util;
using MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;
using MoviesAndShowsCatalog.RatingAndReview.Infrastructure.RabbitMQ;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

Settings settings = new();
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

builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHostedService<RabbitMQSubscriber>();

builder.Services
    .AddSingleton<IEventProcessor, EventProcessor>()
    //Repositories
    .AddScoped<IVisualProductionData, VisualProductionData>()
    .AddScoped<IRatingAndReviewData, RatingAndReviewData>()
    //UseCases
    .AddScoped<ICreateRatingAndReview, CreateRatingAndReview>()
    .AddScoped<IGetRatingsAndReviewsByVisualProductionId, GetRatingsAndReviewsByVisualProductionId>()
    .AddScoped<IGetBestRatedVisualProduction, GetBestRatedVisualProduction>()
    .AddScoped<IGetWorstRatedVisualProduction, GetWorstRatedVisualProduction>();

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
