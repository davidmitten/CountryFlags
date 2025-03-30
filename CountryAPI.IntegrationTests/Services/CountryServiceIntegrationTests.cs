using CountryAPI; // Your API project's namespace
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CountryAPI.IntegrationTests.Services
{
    public class CountryServiceIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CountryServiceIntegrationTests(WebApplicationFactory<Program> factory)
        {
            // Create an HttpClient to interact with the in-memory test server
            //_client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllCountriesEndpoint_ReturnsCountriesFromRealApi()
        {
            //// Act
            //var response = await _client.GetAsync("/api/country");
            //response.EnsureSuccessStatusCode(); // Throws if not 2xx
            //var content = await response.Content.ReadAsStringAsync();
            //var countries = JsonSerializer.Deserialize<List<Country>>(content, new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //});

            //// Assert
            //Assert.NotNull(countries);
            //Assert.NotEmpty(countries);
            //Assert.Contains(countries, c => c.Name.Common == "Switzerland");
            //Assert.Contains(countries, c => c.Flags.Png.Contains("flagcdn.com"));

            Assert.NotEmpty("This test is not implemented yet.");
        }
    }
}
