using System;

namespace Passenger.Core.Domain
{
    public class Node
    {
        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }

        protected Node()
        {
        }

        protected Node(string address, double longitude, double latitude)
        {
            SetAdress(address);
            SetLongitude(longitude);
            SetLatitude(latitude);
        }

        public void SetAdress(string address)
        {
            if(string.IsNullOrWhiteSpace(address))
            {
                throw new Exception("Adress is invalid.");
            }
            else
            {
                Address = address;
            }
        }

        public void SetLongitude(double longitude)
        {
            if(longitude > 180 || longitude < -180)
            {
                throw new Exception("Longitude value is invalid.");
            }
            else if(Longitude == longitude)
            {
                return;
            }
            else
            {
                Longitude = longitude;
            }
        }

        public void SetLatitude(double latitude)
        {
            if(latitude > 90 || latitude < -90)
            {
                throw new Exception("Longitude value is invalid.");
            }
            else if(Latitude == latitude)
            {
                return;
            }
            else
            {
                Latitude = latitude;
            }
        }

        public static Node Create(string adress, double longitude, double latitude)
            => new Node(adress, longitude, latitude);
    }
}