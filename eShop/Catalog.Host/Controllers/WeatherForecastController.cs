using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] _summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
               new WeatherForecast
               (
                   DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                   Random.Shared.Next(-20, 55),
                   _summaries[Random.Shared.Next(_summaries.Length)]
               ))
               .ToArray();
            return forecast;
        }


    }
}
