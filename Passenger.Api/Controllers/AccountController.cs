using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountController(ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler) : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody] ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);
        
            return NoContent();
        }

        [HttpGet]
        [Route("jwt")]
        public async Task<IActionResult> Get()
        {
            var jwt = _jwtHandler.CreateToken("tammasmdka@gmail.com", "user");

            return Json(jwt);
        }
    }
}