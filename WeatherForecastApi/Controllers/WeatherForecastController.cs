using Microsoft.AspNetCore.Mvc;

namespace WeatherForecastApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherDbContext _weatherDbContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                     WeatherDbContext weatherDbContext)
    {
        _logger = logger;
        _weatherDbContext = weatherDbContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Loading weather forecast information");
        return _weatherDbContext.WeatherForecasts.ToArray();
    }
}
