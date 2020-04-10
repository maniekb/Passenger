using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.DTO;
using Xunit;
using FluentAssertions;
using System;
using Xunit.Abstractions;

namespace Passenger.Tests.EndToEnd.Controllers
{
   public class UserControllerTests : ControllerTestsBase
    {
        private readonly ITestOutputHelper _testOutputHelper;
        
        public UserControllerTests(WebApplicationFactory<Startup> factory, ITestOutputHelper testOutputHelper) : base(factory)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task given_valid_email_should_exist()
        {
            var client = Factory.CreateClient();

            var email = "user1@test.com";
            // smth weird
            var response = await client.GetAsync($"users/user1@test.com");
            _testOutputHelper.WriteLine(response.ToString());
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