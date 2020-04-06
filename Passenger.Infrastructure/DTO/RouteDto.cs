using System;
using System.Collections.Generic;

namespace Passenger.Infrastructure.DTO
{
    public class RouteDto
    {
        public ISet<NodeDto> _passengerNodes = new HashSet<NodeDto>();
        public Guid Id { get; set; }
        public IEnumerable<NodeDto> PassengerNodes { get; set; }
    }
}