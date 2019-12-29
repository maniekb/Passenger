using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.DTO;
using Xunit;
using FluentAssertions;
using Passenger.Infrastructure.Commands.Users;

namespace Passenger.Tests.EndToEnd.Controllers
{
   public class AccountControllerTests : ControllerTestsBase
    {
        public AccountControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task given_correct_current_password_and_new_password_it_should_be_changed()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "curpsswd",
                NewPassword = "newpsswd"
            };
            
            var client = Factory.CreateClient();
            var payload = GetPayload(command);

            var response = await client.PutAsync("account/password", payload);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
            
        }
    }
}