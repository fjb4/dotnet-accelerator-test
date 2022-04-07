using System.Collections.Generic;
using System.Linq;
using LinqKit;
using Microsoft.Extensions.Logging;
using MyNamespace.Common.Modules;
using MyNamespace.DotnetAccelerator.Modules.AirportModule.Api;
using MyNamespace.DotnetAccelerator.Modules.WeatherModule;
using MyNamespace.DotnetAccelerator.Persistence;

namespace MyNamespace.DotnetAccelerator.Modules.AirportModule
{
    public partial class AirportService : IService
    {
        private readonly DotnetAcceleratorContext _context;
        private readonly ILogger _logger;

        public AirportService(DotnetAcceleratorContext context, ILogger<AirportService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IAsyncEnumerable<Airport> GetAirports(AirportQuery query)
        {
            var predicate = PredicateBuilder.New<Airport>(true);
            if (query.AirportId != null)
            {
                predicate = predicate.And(x => x.Id == query.AirportId);
            }

            return _context.Airports
                .AsQueryable()
                .Where(predicate)
                .ToAsyncEnumerable();
        }
    }
}