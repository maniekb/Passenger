using System;
using System.Collections.Generic;

namespace Passenger.Infrastructure.DTO
{
    public class RouteDto
    {
        public string Name { get; set; }
        public NodeDto SartNode { get; set; }
        public NodeDto EndNode { get; set; }
    }
}