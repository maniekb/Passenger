using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IRouteManager : IService
    {
        Task<string> GetAddressAsync(double latitude, double longitude);
        int CalculateDistance(double startLatitude, double startLongitude, double endLatitude, double endLongitude);
    }
}