using Microsoft.AspNetCore.Mvc;
using Prometheus;
using PrometheusMonitoringAPI;
using System;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // Define custom metric for tracking the number of API calls
    private static readonly Counter WeatherForecastCounter =
        Metrics.CreateCounter("weather_forecast_api_calls_total", "Total number of calls to WeatherForecast API");

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        // Increment the custom metric
        WeatherForecastCounter.Inc();

        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
         .ToArray();
    }
}
