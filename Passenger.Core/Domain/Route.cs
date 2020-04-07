using System;

namespace Passenger.Core.Domain
{
    public class Route
    {
        public string Name { get; protected set; }
        public Node SartNode { get; protected set; }
        public Node EndNode { get; protected set; }

        public Route(string name, Node start, Node end)
        {
            Name = name;
            SartNode = start;
            EndNode = end;
        }

        public static Route Create(string name, Node start, Node end)
            => new Route(name, start, end);
    }
}