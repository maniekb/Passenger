using System;
using System.Collections.Generic;
using System.Linq;
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
            var users = await _userService.BrowseAsync();
            if(users.Any())
            {
                return;
            }
            
            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();
            for(var i = 1; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}"; 
                await _userService.RegisterAsync(userId, $"{username}@test.com", username, "secret", "user");

                await _driverService.CreateAsync(userId);
                await _driverService.SetVehicle(userId, "Masserati", "Quattroporte");

                await _driverRouteService.AddAsync(userId, "School route", 1.0, 2.0, 2.0, 4.0);
                await _driverRouteService.AddAsync(userId, "Job route", 1.0, 2.0, 2.0, 4.0);
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