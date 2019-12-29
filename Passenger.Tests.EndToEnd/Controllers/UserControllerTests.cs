using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.DTO;
using Xunit;
using FluentAssertions;

namespace Passenger.Tests.EndToEnd.Controllers
{
   public class UserControllerTests : ControllerTestsBase
    {
        public UserControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("user1@mail.com")]
        [InlineData("user2@mail.com")]
        [InlineData("user3@mail.com")]
        public async Task given_valid_email_should_exist(string email)
        {
            var client = Factory.CreateClient();

            var response = await client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            user.Email.ShouldBeEquivalentTo(email);
        }

        [Fact]
        public async Task given_invalid_email_should_not_exist()
        {
            var email = "wrongmail@mail.com";
            var client = Factory.CreateClient();

            var response = await client.GetAsync($"users/{email}");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
            
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new {
                Email = "user123@mail.com",
                Username = "user",
                Password = "passwd"
            };

            var client = Factory.CreateClient();
            var payload = GetPayload(request);
            var response = await client.PostAsync("users", payload);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{request.Email}");
        }
    }
}