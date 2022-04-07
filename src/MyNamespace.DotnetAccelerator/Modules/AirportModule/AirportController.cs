using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNamespace.Common.Messaging;
using MyNamespace.DotnetAccelerator.Modules.AirportModule.Api;


namespace MyNamespace.DotnetAccelerator.Modules.AirportModule
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly IMessageBus _messageBus;

        public AirportController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [HttpGet(Name = "Airport_GetAll")]

        public IAsyncEnumerable<Airport> Get() => Get(null);
        [HttpGet("{airportId}", Name = "Airport_GetById")]

        public IAsyncEnumerable<Airport> Get(string? airportId) => _messageBus.Send(new AirportQuery{ AirportId = airportId });
        
    }
}