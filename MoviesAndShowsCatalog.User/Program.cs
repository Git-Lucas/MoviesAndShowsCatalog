using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionStringMySql = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new Exception("Connection string was not found.");
builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseMySql(connectionStringMySql, ServerVersion.AutoDetect(connectionStringMySql)));

builder.Services.AddScoped<IUserData, UserData>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
