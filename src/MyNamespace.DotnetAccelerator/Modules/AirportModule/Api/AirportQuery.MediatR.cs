using System.Collections.Generic;
using MediatR;

namespace MyNamespace.DotnetAccelerator.Modules.AirportModule.Api
{
    partial class AirportQuery : IRequest<IAsyncEnumerable<Airport>>
    {
        
    }
}