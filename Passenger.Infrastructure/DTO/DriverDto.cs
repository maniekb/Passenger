using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid UserId { get; set;}
        public Vehicle Vehicle { get; set; }
        public IEnumerable<Route> Routes { get; set; } 
        public IEnumerable<DailyRoute> DailyRoutes { get; set; }

        public DriverDto(Guid userId, Vehicle vehicle, IEnumerable<Route> routes, IEnumerable<DailyRoute> dailyRoutes)
        {
            UserId = userId;
            Vehicle = vehicle;
            Routes = routes;
            DailyRoutes = dailyRoutes;
        }
    }
}