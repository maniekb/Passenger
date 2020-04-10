using System;

namespace Passenger.Core.Domain
{
    public class Route
    {
        public string Name { get; protected set; }
        public Node SartNode { get; protected set; }
        public Node EndNode { get; protected set; }
        public int Distance { get; protected set; }

        public Route(string name, Node start, Node end, int distance)
        {
            Name = name;
            SartNode = start;
            EndNode = end;
            Distance = distance;
        }

        public static Route Create(string name, Node start, Node end, int distance)
            => new Route(name, start, end, distance);
    }
}