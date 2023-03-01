using database;
using domain;
using Microsoft.EntityFrameworkCore;
using query.me.domain;
using query.me.efcore.database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("WeatherForecast"));
builder.Services.AddScoped<IGetEntitiesQuery<WeatherForecast>, GetEntitiesQuery<WeatherForecast, ApplicationDbContext>>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
