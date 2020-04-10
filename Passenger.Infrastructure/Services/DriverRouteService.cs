using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Infrastructure.Services
{
    public class DriverRouteService : IDriverRouteService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IRouteManager _routeManager;
        private readonly IMapper _mapper;

        public DriverRouteService(IDriverRepository driverRepository, IRouteManager routeManager, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _routeManager = routeManager;
            _mapper = mapper;
        }

        public async Task AddAsync(Guid userId, string name, double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            var startAddress = await _routeManager.GetAddressAsync(startLatitude, startLongitude);
            var endAddress = await _routeManager.GetAddressAsync(endLatitude, endLongitude);
            var startNode = Node.Create(startAddress, startLongitude, startLatitude);
            var endNode = Node.Create(endAddress, endLongitude, endLatitude);
            var distance = _routeManager.CalculateDistance(startLatitude, startLongitude, endLatitude, endLongitude);
            driver.AddRoute(name, startNode, endNode, distance);
        }

        public async Task DeleteAsync(Guid userId, string name)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);

            driver.DeleteRoute(name);
            await _driverRepository.UpdateAsync(driver);
        }
    }
}