using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Xunit;
using Microsoft.AspNetCore.Hosting.Server;


namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UserControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UserControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }


        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
        //     var email = "user1@gmail.com";
        //     var response = await _client.GetAsync($"users/{email}");
        //     response.EnsureSuccessStatusCode();

        //     var responseString = await response.Content.ReadAsStringAsync();
        //     var user = JsonConvert.DeserializeObject<UserDto>(responseString);

        //     user.Email.Should().BeEquivalentTo(email);

        }
    }
}