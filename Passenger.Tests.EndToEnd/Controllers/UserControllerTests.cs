using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.DTO;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
   public class UserControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UserControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("user1@mail.com")]
        [InlineData("user2@mail.com")]
        [InlineData("user3@mail.com")]
        public async Task given_valid_email_should_exist(string email)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            Assert.True(user.Email == email);
        }

        [Fact]
        public async Task given_invalid_email_should_not_exist()
        {
            var email = "wrongmail@mail.com";
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"users/{email}");
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
    }
}