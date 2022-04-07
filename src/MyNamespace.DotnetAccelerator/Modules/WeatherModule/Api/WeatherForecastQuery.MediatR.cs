using System.Collections.Generic;
using MediatR;

namespace MyNamespace.DotnetAccelerator.Modules.WeatherModule.Api
{
    partial class WeatherForecastQuery : IRequest<IAsyncEnumerable<WeatherForecast>>
    {
        
    }
}