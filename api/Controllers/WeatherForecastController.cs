using database;
using Microsoft.AspNetCore.Mvc;
using query.me.efcore.database;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly GetEntitiesQuery<WeatherForecast, ApplicationDbContext> _getEntitiesQuery;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, GetEntitiesQuery<WeatherForecast, ApplicationDbContext> getEntitiesQuery)
    {
        _logger = logger;
        _getEntitiesQuery = getEntitiesQuery;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await _getEntitiesQuery.Execute(wf => true);
    }
}
