using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoviesAndShowsCatalog.MovieAndShow.Application.Authentication;
using MoviesAndShowsCatalog.MovieAndShow.Application.MessageQueue;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Events;
using MoviesAndShowsCatalog.MovieAndShow.Infrastructure.Data;
using MoviesAndShowsCatalog.MovieAndShow.Infrastructure.Data.Repositories;
using MoviesAndShowsCatalog.MovieAndShow.Infrastructure.MessageQueue;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

byte[] key = Encoding.ASCII.GetBytes(Settings.Secret);
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
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddScoped<IVisualProductionRepository, VisualProductionEF>()
    .AddScoped<ConfigRabbitMQ>()
    .AddScoped<IMessageQueueProducer, RabbitMQProducer>()
    .AddScoped<VisualProductionCreated>()
    .AddScoped<VisualProductionDeleted>();

var app = builder.Build();

IServiceScope scope = app.Services.CreateScope();
DatabaseContext databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
await databaseContext.Database.MigrateAsync();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
