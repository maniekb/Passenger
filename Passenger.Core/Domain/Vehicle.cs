using System;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public string Brand { get; protected set;}
        public string Name { get; protected set; }
        public int Seats { get; protected set;}

        public Vehicle()
        {
        }
        private Vehicle(string brand, string name, int seats)
        {
            SetBrand(brand);
            SetName(name);
            SetSeats(seats);
        }

        private void SetBrand(string brand)
        {
            if(brand == null)
            {
                throw new Exception("Please provide valid data.");
            }
            else if(brand == Brand)
            {
                return;
            }

            Brand = brand;
        }

        private void SetName(string name)
        {
            if(name == null)
            {
                throw new Exception("Please provide valid data.");
            }
            else if(name == Name)
            {
                return;
            }

            Name = name;
        }

        private void SetSeats(int seats)
        {
            if(seats < 0)
            {
                throw new Exception("Please provide valid data.");
            }
            else if(seats == Seats)
            {
                return;
            }

            Seats = seats;
        }

        public static Vehicle Create(string brand, string name, int seats)
            => new Vehicle(brand,name,seats);
    } 
}