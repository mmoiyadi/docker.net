using System;

namespace WeatherForecastAdmin.Integrations
{
    public interface IWeatherForecastAddNotification
    {
        void WeatherForecastAdded(DateTime date, int temperatureInC, string summary);
    }
}