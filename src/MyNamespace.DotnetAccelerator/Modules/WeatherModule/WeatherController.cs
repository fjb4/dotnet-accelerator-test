using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNamespace.Common.Messaging;
using MyNamespace.DotnetAccelerator.Modules.WeatherModule.Api;



namespace MyNamespace.DotnetAccelerator.Modules.WeatherModule
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IMessageBus _messageBus;

        public WeatherController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [HttpGet]

        public IAsyncEnumerable<WeatherForecast> Get([FromQuery] WeatherForecastQuery query) => _messageBus.Send(query);

        [HttpGet("{airportId}", Name = "Weather_GetById")]

        public async Task<ActionResult<WeatherForecast>> Get(string airportId)
        {
            var forecast = await Get(new WeatherForecastQuery {AirportId = airportId}).FirstOrDefaultAsync();
            if (forecast == null)
            {
                return NotFound(airportId);
            }
            return forecast;
        }

        [HttpPost]
        [HttpPut(Name = "Weather_Put")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<WeatherForecast>> Post(WeatherForecast forecast)
        {
            return await _messageBus.Send(forecast);
        }
    }
}