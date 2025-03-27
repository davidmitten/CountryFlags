using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CountryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CountryController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("flags")]
        public async Task<IActionResult> GetCountryFlags()
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonSerializer.Deserialize<List<Country>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var countryFlags = countries?.Select(c => new
            {
                c.Name.Common,
                c.Flags.Png
            }).ToList();

            return Ok(countryFlags);
        }

        [HttpGet("details/{name}")]
        public async Task<IActionResult> GetCountryDetails(string name)
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonSerializer.Deserialize<List<Country>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var country = countries?.FirstOrDefault(c => c.Name.Common.Equals(name, StringComparison.OrdinalIgnoreCase) || c.Name.Official.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }
    }
}



//using Microsoft.AspNetCore.Mvc;
//using System.Net.Http;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace CountryApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CountryController : ControllerBase
//    {
//        private readonly HttpClient _httpClient;

//        public CountryController(IHttpClientFactory httpClientFactory)
//        {
//            _httpClient = httpClientFactory.CreateClient();
//        }

//        [HttpGet("flags")]
//        public async Task<IActionResult> GetCountryFlags()
//        {
//            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
//            response.EnsureSuccessStatusCode();
//            var content = await response.Content.ReadAsStringAsync();
//            var countries = JsonSerializer.Deserialize<List<Country>>(content);
//            return Ok(countries);
//        }

//        [HttpGet("details")]
//        public async Task<IActionResult> GetCountryDetails()
//        {
//            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
//            response.EnsureSuccessStatusCode();
//            var content = await response.Content.ReadAsStringAsync();
//            var countries = JsonSerializer.Deserialize<List<Country>>(content);
//            return Ok(countries);
//        }
//    }
//}