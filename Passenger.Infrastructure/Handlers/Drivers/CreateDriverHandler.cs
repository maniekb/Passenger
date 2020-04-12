using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class CreateDriverHandler : ICommandHandler<CreateDriver>
    {
        private readonly IDriverService _driverService;

        private readonly IHandler _handler;
        public CreateDriverHandler(IHandler handler, IDriverService driverService)
        {
             _driverService = driverService;
             _handler = handler;
        }

        public async Task HandleAsync(CreateDriver command)
            => await _handler
            .Run(async () => await _driverService.CreateAsync(command.UserId))
            .Next()
            .Run(async () =>  
            {
                    var vehicle = command.Vehicle;
                    await _driverService.SetVehicle(command.UserId, vehicle.Brand, vehicle.Name);
            })
            .ExecuteAsync();
    }
}