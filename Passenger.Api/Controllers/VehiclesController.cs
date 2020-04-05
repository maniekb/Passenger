using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using Newtonsoft.Json;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;

namespace Passenger.Api.Controllers
{
    public class VehiclesController : ApiControllerBase
    {
        private readonly IVehicleProvider _vehicleProvider;
        public VehiclesController(IVehicleProvider vehicleProvider, 
                               ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _vehicleProvider = vehicleProvider;
        }

        public async Task<IActionResult> GetAction()
        {
            var vehicles = await _vehicleProvider.BrowseAsync();

            return Json(vehicles);
        }
    }
}
