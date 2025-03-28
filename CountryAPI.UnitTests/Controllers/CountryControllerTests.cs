//using CountryApi.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using Xunit;

//namespace CountryAPI.UnitTests.Controllers
//{
//    public class CountryControllerTests
//    {
//        private readonly CountryController _controller;

//        public CountryControllerTests()
//        {
//            _controller = new CountryController();
//        }

//        [Fact]
//        public void GetCountries_ReturnsOk_WithCountryList()
//        {
//            // Act
//            var result = _controller.GetCountries();

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var countries = Assert.IsType<List<string>>(okResult.Value);
//            Assert.Equal(3, countries.Count);
//            Assert.Contains("USA", countries);
//            Assert.Contains("Canada", countries);
//            Assert.Contains("Mexico", countries);
//        }

//        [Fact]
//        public void GetCountries_ReturnsNonEmptyList()
//        {
//            // Act
//            var result = _controller.GetCountries();

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var countries = Assert.IsType<List<string>>(okResult.Value);
//            Assert.NotEmpty(countries);
//        }
//    }
//}