using System;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class CreateDriverRoute : AuthenticatedCommandBase
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EnLongitude { get; set; }
    }
}