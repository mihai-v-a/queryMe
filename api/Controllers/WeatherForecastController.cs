using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IGetEntitiesQuery<WeatherForecast> _getEntitiesQuery;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IGetEntitiesQuery<WeatherForecast> getEntitiesQuery)
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
