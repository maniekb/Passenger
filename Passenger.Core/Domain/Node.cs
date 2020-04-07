using System;

namespace Passenger.Core.Domain
{
    public class Node
    {
        public string Adress { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }

        protected Node()
        {
        }

        protected Node(string adress, double longitude, double latitude)
        {
            SetAdress(adress);
            SetLongitude(longitude);
            SetLatitude(latitude);
        }

        public void SetAdress(string adress)
        {
            if(string.IsNullOrWhiteSpace(adress))
            {
                throw new Exception("Adress is invalid.");
            }
            else if (Adress.Equals(adress))
            {
                 return;
            }
            else
            {
                Adress = adress;
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