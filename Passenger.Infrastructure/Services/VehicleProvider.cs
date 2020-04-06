using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class VehicleProvider : IVehicleProvider
    {
        private readonly IMemoryCache _cache;
        private readonly static string CacheKey = "vehicles";

        private static readonly IDictionary<string, IEnumerable<VehicleDetails>> availableVehicles = 
            new Dictionary<string, IEnumerable<VehicleDetails>>
            {
                ["Audi"] = new List<VehicleDetails>
                {
                    new VehicleDetails("RS8", 5)
                },
                ["Ford"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Fiesta", 5)
                },
                ["Volkswagen"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Passat", 5),
                    new VehicleDetails("Golf", 5)
                },  
                ["Kia"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Rio", 5)
                },
                ["Mercedes"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Serie A", 5)
                }      
            };

    
        public VehicleProvider(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<IEnumerable<VehicleDto>> BrowseAsync()
        {
            var vehicles = _cache.Get<IEnumerable<VehicleDto>>(CacheKey);
            if(vehicles == null)
            {
                vehicles = await GetAllAsync();
                _cache.Set(CacheKey, vehicles);
            }

            return vehicles;
        }

        public async Task<VehicleDto> GetAsync(string brand, string name)
        {
            if(availableVehicles.ContainsKey(brand))
            {
                throw new Exception($"Vehcile: {brand} is not available.");
            }

            var vehciles = availableVehicles[brand];
            var vehicle = vehciles.SingleOrDefault(x => x.Name == name);
            if(vehicle == null)
            {
                throw new Exception($"Vehicle: {name} for brand: {brand} is not available.");
            }

            return await Task.FromResult(new VehicleDto(brand, name, vehicle.Seats));
        }

        public async Task<IEnumerable<VehicleDto>> GetAllAsync()
            => await Task.FromResult(availableVehicles.GroupBy(x => x.Key)
                         .SelectMany(g => g.SelectMany(v => v.Value.Select(c => new VehicleDto(v.Key, c.Name, c.Seats)))));

        private class VehicleDetails
        {
            public string Name { get; }
            public int Seats { get; }

            public VehicleDetails(string name, int seats)
            {
                Name = name;
                Seats = seats;
            }
        }
    }
}