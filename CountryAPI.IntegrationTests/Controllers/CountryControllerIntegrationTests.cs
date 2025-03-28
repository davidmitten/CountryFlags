//using CountryAPI; // Ensure this matches your API project's namespace
//using CountryAPI.Models;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using Moq;
//using Moq.Protected;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Xunit;

//namespace CountryAPI.IntegrationTests.Controllers
//{
//    public class CountryControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
//    {
//        private readonly HttpClient _client;

//        public CountryControllerIntegrationTests(CustomWebApplicationFactory factory)
//        {
//            _client = factory.CreateClient();
//        }

//        [Fact]
//        public async Task GetCountries_ReturnsSuccess_WithCountryFlags()
//        {
//            var response = await _client.GetAsync("/countries");
//            response.EnsureSuccessStatusCode();
//            var content = await response.Content.ReadAsStringAsync();
//            var countryFlags = JsonSerializer.Deserialize<List<Flag>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
//            Assert.NotNull(countryFlags);
//            Assert.Equal(2, countryFlags.Count);
//            Assert.Contains(countryFlags, f => f.Alt == "USA" && f.Png == "https://flagcdn.com/usa.png");
//        }

//        [Fact]
//        public async Task GetCountryDetails_ReturnsSuccess_WithValidName()
//        {
//            var response = await _client.GetAsync("/countries/details/USA");
//            response.EnsureSuccessStatusCode();
//            var content = await response.Content.ReadAsStringAsync();
//            var country = JsonSerializer.Deserialize<Country>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
//            Assert.NotNull(country);
//            Assert.Equal("USA", country.Name.Common);
//            Assert.Equal("https://flagcdn.com/usa.png", country.Flag.Png);
//        }

//        [Fact]
//        public async Task GetCountryDetails_ReturnsNotFound_WithInvalidName()
//        {
//            var response = await _client.GetAsync("/countries/details/InvalidCountry");
//            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
//        }
//    }

//    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
//    {
//        protected override void ConfigureWebHost(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices(services => {
//                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IHttpClientFactory));
//                if (descriptor != null) services.Remove(descriptor);

//                var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
//                mockHttpMessageHandler.Protected()
//                    .Setup<Task<HttpResponseMessage>>(
//                        "SendAsync",
//                        ItExpr.IsAny<HttpRequestMessage>(),
//                        ItExpr.IsAny<CancellationToken>())
//                    .ReturnsAsync(() => {
//                        var mockCountries = new List<Country> {
//                            new Country {
//                                Name = new CountryName { Common = "USA", Official = "United States of America" },
//                                Flag = new Flag { Png = "https://flagcdn.com/usa.png" }
//                            },
//                            new Country {
//                                Name = new CountryName { Common = "Canada", Official = "Canada" },
//                                Flag = new Flag { Png = "https://flagcdn.com/canada.png" }
//                            }
//                        };
//                        var jsonContent = JsonSerializer.Serialize(mockCountries);
//                        return new HttpResponseMessage
//                        {
//                            StatusCode = System.Net.HttpStatusCode.OK,
//                            Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
//                        };
//                    });

//                var mockHttpClient = new HttpClient(mockHttpMessageHandler.Object)
//                {
//                    BaseAddress = new Uri("https://restcountries.com/v3.1/")
//                };

//                services.AddSingleton<IHttpClientFactory>(new MockHttpClientFactory(mockHttpClient));
//            });
//        }
//    }

//    public class MockHttpClientFactory : IHttpClientFactory
//    {
//        private readonly HttpClient _httpClient;
//        public MockHttpClientFactory(HttpClient httpClient) => _httpClient = httpClient;
//        public HttpClient CreateClient(string name) => _httpClient;
//    }
//}