using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Exceptions;
using AspNetCore.Exceptions;

namespace AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{city}")]
        public IActionResult Get(string city)
        {
            var service = new WeatherForecastService();

            try
            {
                var data = service.GetTemperature(city);

                return Ok(data);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }
    }

    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetTemperature(string city)
        {
            if ("SP" != city?.ToUpper())
                throw new CityNotFoundException($"The city with the name {city?.ToUpper()} does not exist.");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }
    }
}