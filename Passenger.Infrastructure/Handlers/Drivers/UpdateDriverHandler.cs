using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class UpdateDriverHandler : ICommandHandler<UpdateDriver>
    {
        private readonly IDriverService _driverService;
        private readonly IHandler _handler;
        public UpdateDriverHandler(IHandler handler, IDriverService driverService)
        {
             _driverService = driverService;
             _handler = handler;
        }

        public async Task HandleAsync(UpdateDriver command)
            => await _handler
            .Run(async () => 
            {
                var vehicle = command.Vehicle;
                await _driverService.SetVehicle(command.UserId, vehicle.Brand, vehicle.Name);
            })
            .ExecuteAsync();

    }
}