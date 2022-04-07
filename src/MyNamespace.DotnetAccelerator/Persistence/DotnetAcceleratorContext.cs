using Microsoft.EntityFrameworkCore;
using MyNamespace.DotnetAccelerator.Modules.AirportModule.Api;
using MyNamespace.DotnetAccelerator.Modules.WeatherModule.Api;

namespace MyNamespace.DotnetAccelerator.Persistence
{
    public class DotnetAcceleratorContext : DbContext
    {
        protected DotnetAcceleratorContext()
        {
        }

        public DotnetAcceleratorContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
        public DbSet<Airport> Airports => Set<Airport>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().HasData(new Airport {Id = "YYZ", Name = "Toronto"});
            modelBuilder.Entity<Airport>().HasData(new Airport {Id = "JFK", Name = "New York"});
        }
    }
}