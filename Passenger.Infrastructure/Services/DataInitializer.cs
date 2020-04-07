using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Passenger.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IDriverRouteService _driverRouteService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService, IDriverService driverService, 
                               IDriverRouteService driverRouteService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _driverService = driverService;
            _driverRouteService = driverRouteService;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();
            for(var i = 1; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}"; 
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", username, "secret", "user"));

                tasks.Add(_driverService.CreateAsync(userId));
                tasks.Add(_driverService.SetVehicle(userId, "Masserati", "Quattroporte"));

                tasks.Add(_driverRouteService.AddAsync(userId, "School route", 1.0, 2.0, 2.0, 4.0));
                tasks.Add(_driverRouteService.AddAsync(userId, "Job route", 1.0, 2.0, 2.0, 4.0));
            }

            for(var i = 1; i <= 3; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", username, "secret", "admin"));
            }

            await Task.WhenAll(tasks);
            
            _logger.LogTrace("Data was initialized.");
        }
    }
}