using System;
using System.Net;
using System.Text.Json;
using FlagExplorerAPI.Models;
using FlagExplorerAPI.Service;
using Moq;
using Moq.Protected;

namespace FlagExplorerAPI.Tests
{
    public class CountryServiceTests
    {
        private HttpClient CreateMockHttpClient(object responseObject)
        {
            var handlerMock = new Mock<HttpMessageHandler>();

            var json = JsonSerializer.Serialize(responseObject);
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json),
            };

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage);

            var client = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://restcountries.com/")
            };

            return client;
        }

        [Fact]
        public async Task GetAllCountriesAsync_ShouldReturnResults()
        {
            // Arrange
            var service = new CountryService();

            // Act
            var result = await service.GetAllCountriesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetCountryByNameAsync_ReturnsMatch_WhenExists()
        {
            var response = new List<ClientCountryModel>
        {
            new ClientCountryModel
            {
                Name = new Name { Common = "Germany" },
                Capital = new List<string> { "Berlin" },
                Population = 83000000,
                Flags = new ()
                {
                    Png = "https://flagcdn.com/w320/gs.png"
                }
            }
        };

            var httpClient = CreateMockHttpClient(response);
            var service = new CountryService();

            var country = await service.GetCountryByNameAsync("germany");

            Assert.NotNull(country);
            Assert.Equal("Germany", country?.name);
        }
    }
}

