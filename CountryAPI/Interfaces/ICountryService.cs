namespace CountryApi.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task<Country?> GetCountryDetailsAsync(string name);
    }
}