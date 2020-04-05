namespace Passenger.Infrastructure.DTO
{
    public class VehicleDTO
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }

        public VehicleDTO(string brand, string name, int seats)
        {
            Brand = brand;
            Name = name;
            Seats = seats;
        }
    }
}