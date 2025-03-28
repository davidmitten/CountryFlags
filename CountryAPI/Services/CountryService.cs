using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountryApi.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://restcountries.com/v3.1/");
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            var response = await _httpClient.GetAsync("all");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonSerializer.Deserialize<List<Country>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return countries?.Select(c => new Country
            {
                Name = c.Name,
                Flags = c.Flags
            }).ToList() ?? new List<Country>();
        }

        public async Task<Country?> GetCountryDetailsAsync(string name)
        {
            var response = await _httpClient.GetAsync("all"); //there may be a more efficient way of returning only the country selected, rather than filtering after retrieving all countries, Example, I may implement a memory cache to use here
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonSerializer.Deserialize<List<Country>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return countries?.FirstOrDefault(c =>
                c.Name.Common.Equals(name, StringComparison.OrdinalIgnoreCase) ||
                c.Name.Official.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}