using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid UserId { get; set;}
        public Vehicle Vehicle { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}