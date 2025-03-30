using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CountryApi.Services;
using Moq;
using Moq.Protected;
using Xunit;

namespace CountryApi.Tests
{
    public class CountryServiceUnitTests
    {
        private readonly Mock<HttpMessageHandler> _handlerMock;
        private readonly HttpClient _httpClient;
        private readonly CountryService _service;

        public CountryServiceUnitTests()
        {
            _handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _httpClient = new HttpClient(_handlerMock.Object)
            {
                BaseAddress = new Uri("https://restcountries.com/v3.1/")
            };
            _service = new CountryService(_httpClient); // Use the HttpClient constructor
        }

        [Fact]
        public async Task GetAllCountriesAsync_ReturnsCountries_WhenApiSucceeds()
        {
            // Arrange
            var jsonResponse = @"[
                {
                    ""name"": { ""common"": ""Switzerland"", ""official"": ""Swiss Confederation"" },
                    ""flags"": { ""png"": ""https://flagcdn.com/w320/ch.png"", ""svg"": ""https://flagcdn.com/ch.svg"", ""alt"": ""Swiss flag"" }
                },
                {
                    ""name"": { ""common"": ""Grenada"", ""official"": ""Grenada"" },
                    ""flags"": { ""png"": ""https://flagcdn.com/w320/gd.png"", ""svg"": ""https://flagcdn.com/gd.svg"", ""alt"": ""Grenada flag"" }
                }
            ]";
            SetupHttpResponse(HttpStatusCode.OK, jsonResponse);

            // Act
            var result = await _service.GetAllCountriesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Switzerland", result[0].Name.Common);
            Assert.Equal("https://flagcdn.com/w320/ch.png", result[0].Flags.Png);
            Assert.Equal("Grenada", result[1].Name.Common);
            Assert.Equal("https://flagcdn.com/w320/gd.png", result[1].Flags.Png);
        }

        
        [Fact]
        public async Task GetCountryDetailsAsync_ReturnsCountry_WhenNameMatches()
        {
            // Arrange
            var jsonResponse = @"[
                {
                    ""name"": { ""common"": ""Switzerland"", ""official"": ""Swiss Confederation"" },
                    ""flags"": { ""png"": ""https://flagcdn.com/w320/ch.png"", ""svg"": ""https://flagcdn.com/ch.svg"", ""alt"": ""Swiss flag"" }
                }
            ]";
            SetupHttpResponse(HttpStatusCode.OK, jsonResponse);

            // Act
            var result = await _service.GetCountryDetailsAsync("switzerland");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Switzerland", result.Name.Common);
            Assert.Equal("Swiss Confederation", result.Name.Official);
            Assert.Equal("https://flagcdn.com/w320/ch.png", result.Flags.Png);
        }

        [Fact]
        public async Task GetCountryDetailsAsync_ReturnsNull_WhenNameNotFound()
        {
            // Arrange
            var jsonResponse = @"[
                {
                    ""name"": { ""common"": ""Switzerland"", ""official"": ""Swiss Confederation"" },
                    ""flags"": { ""png"": ""https://flagcdn.com/w320/ch.png"", ""svg"": ""https://flagcdn.com/ch.svg"", ""alt"": ""Swiss flag"" }
                }
            ]";
            SetupHttpResponse(HttpStatusCode.OK, jsonResponse);

            // Act
            var result = await _service.GetCountryDetailsAsync("Canada");

            // Assert
            Assert.Null(result);
        }

        
        private void SetupHttpResponse(HttpStatusCode statusCode, string content)
        {
            _handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content)
                })
                .Verifiable();
        }
    }
}