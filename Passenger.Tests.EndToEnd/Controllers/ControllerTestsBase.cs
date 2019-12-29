using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Passenger.Api;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
   public class ControllerTestsBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> Factory;

        public ControllerTestsBase(WebApplicationFactory<Startup> factory)
        {
            Factory = factory;
        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}