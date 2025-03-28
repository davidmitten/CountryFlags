using CountryAPI.Models;

namespace CountryAPI.Services
{
    public interface ICountryService
    {
        Task<List<CountryFlagDto>> GetAllCountriesAsync();
        Task<Country?> GetCountryDetailsAsync(string name);
    }
}