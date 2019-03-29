using System;

namespace Passenger.Core.Domain
{
    public class Route
    {
        public Guid Id { get; protected set; }
        public Node SartNode { get; protected set; }
        public Node EndNode { get; protected set; }
    }
}