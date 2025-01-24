using KamathResidency.Infrastructure;
using KamathResidency.Repos.Implementations;
using KamathResidency.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
var config = builder.Configuration;

// Add configuration

config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    ;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<KamahResidencyContext>(options => options.UseSqlite(config.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBookingRepo, BookingRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

