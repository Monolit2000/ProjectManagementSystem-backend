using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskАndProjectManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectContrller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
         };

        private readonly IMediator _mediator;
        private readonly ILogger<ProjectContrller> _logger;

        public ProjectContrller(IMediator mediator, ILogger<ProjectContrller> logger)
        {
            _mediator = mediator;   
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}