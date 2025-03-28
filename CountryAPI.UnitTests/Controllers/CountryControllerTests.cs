//using CountryApi.Controllers;
//using CountryAPI.Models;
//using CountryAPI.Services;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Xunit;

//namespace CountryAPI.UnitTests.Controllers
//{
//    public class CountryControllerTests
//    {
//        private readonly Mock<ICountryService> _mockCountryService;
//        private readonly CountryController _controller;

//        public CountryControllerTests()
//        {
//            _mockCountryService = new Mock<ICountryService>();
//            _controller = new CountryController(_mockCountryService.Object);
//        }

//        [Fact]
//        public async Task GetCountries_ReturnsOk_WithCountryFlags()
//        {
//            // Arrange
//            var countryFlags = new List<CountryFlagDto> {
//                new CountryFlagDto { Common = "USA", Png = "https://flagcdn.com/usa.png" },
//                new CountryFlagDto { Common = "Canada", Png = "https://flagcdn.com/canada.png" }
//            };
//            _mockCountryService.Setup(s => s.GetAllCountriesAsync()).ReturnsAsync(countryFlags);

//            // Act
//            var result = await _controller.GetCountries();

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnedFlags = Assert.IsType<List<CountryFlagDto>>(okResult.Value);
//            Assert.Equal(2, returnedFlags.Count);
//            Assert.Contains(returnedFlags, f => f.Common == "USA" && f.Png == "https://flagcdn.com/usa.png");
//        }

//        [Fact]
//        public async Task GetCountryDetails_ReturnsOk_WithValidName()
//        {
//            // Arrange
//            var country = new Country
//            {
//                Name = new CountryName { Common = "USA", Official = "United States of America" },
//                Flag = new Flag { Png = "https://flagcdn.com/usa.png" }
//            };
//            _mockCountryService.Setup(s => s.GetCountryDetailsAsync("USA")).ReturnsAsync(country);

//            // Act
//            var result = await _controller.GetCountryDetails("USA");

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnedCountry = Assert.IsType<Country>(okResult.Value);
//            Assert.Equal("USA", returnedCountry.Name.Common);
//            Assert.Equal("https://flagcdn.com/usa.png", returnedCountry.Flag.Png);
//        }

//        [Fact]
//        public async Task GetCountryDetails_ReturnsNotFound_WithInvalidName()
//        {
//            // Arrange
//            _mockCountryService.Setup(s => s.GetCountryDetailsAsync("InvalidCountry")).ReturnsAsync((Country?)null);

//            // Act
//            var result = await _controller.GetCountryDetails("InvalidCountry");

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }
//    }
//}