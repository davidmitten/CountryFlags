using Microsoft.AspNetCore.Mvc;
using CountryApi.Services;
using System.Threading.Tasks;

namespace CountryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
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