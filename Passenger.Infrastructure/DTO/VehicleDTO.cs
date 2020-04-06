namespace Passenger.Infrastructure.DTO
{
    public class VehicleDto
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }

        public VehicleDto(string brand, string name, int seats)
        {
            Brand = brand;
            Name = name;
            Seats = seats;
        }
    }
}