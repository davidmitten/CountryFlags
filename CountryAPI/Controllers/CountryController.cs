using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using CountryAPI.Services;

namespace CountryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        //private readonly HttpClient _httpClient;
        private readonly ICountryService _countryService;
        
        public CountryController(ICountryService countryService)
        {
            //_httpClient = httpClientFactory.CreateClient();
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        [HttpGet()]
        public async Task<IActionResult> GetCountries()
        {
            //var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //var countries = JsonSerializer.Deserialize<List<Country>>(content, new JsonSerializerOptions
            var countryFlags = await _countryService.GetAllCountriesAsync();
            //{
            //    PropertyNameCaseInsensitive = true
            //});

            //var countryFlags = countries?.Select(c => new
            //{
            //    c.Name.Common,
            //    c.Flags.Png
            //}).ToList();

            return Ok(countryFlags);
        }

        [HttpGet("details/{name}")]
        public async Task<IActionResult> GetCountryDetails(string name)
        {
            //var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //var countries = JsonSerializer.Deserialize<List<Country>>(content, new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //});

            //var country = countries?.FirstOrDefault(c => c.Name.Common.Equals(name, StringComparison.OrdinalIgnoreCase) || c.Name.Official.Equals(name, StringComparison.OrdinalIgnoreCase));
            var country = await _countryService.GetCountryDetailsAsync(name);
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
//        public async Task<IActionResult> GetCountries()
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