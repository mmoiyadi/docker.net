using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherForecastProcessor;
using WeatherForecastProcessor.Repositories;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
