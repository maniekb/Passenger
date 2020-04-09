using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [Route("driver/routes")]
    public class DriverRoutesController : ApiControllerBase
    {
        private readonly IDriverRouteService _driverRouteService;
        public DriverRoutesController(ICommandDispatcher commandDispatcher, IDriverRouteService driverRouteService) : base(commandDispatcher)
        {
            _driverRouteService = driverRouteService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDriverRoute command)
        {
            await DispatchAsync(command);

            return NoContent();
        }        

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            var command = new DeleteDriverRoute
            {
                Name = name
            };
            await DispatchAsync(command);

            return NoContent();
        }  
    }
}