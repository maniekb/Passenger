using System;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Repositories;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly InMemoryDriverRepository _driverRepository;

        DriverService(InMemoryDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public DriverDto Get(Guid userId)
        {
            var driver = _driverRepository.Get(userId);

            return new DriverDto(driver.UserId, driver.Vehicle, driver.Routes, driver.DailyRoutes);
        }
    }
}