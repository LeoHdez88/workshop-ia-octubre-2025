using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Frontend.DTOs;
using Frontend.Services;
using Moq;
using Moq.Protected;
using Xunit;

namespace Frontend.Tests.Services
{
    public class LocationServiceTests
    {
        [Fact]
        public async Task GetLocationsAsync_ReturnsLocations_WhenApiReturnsData()
        {
            // Arrange
            var locations = new List<LocationDto>
            {
                new LocationDto { Id = Guid.NewGuid(), City = "Ciudad 1", Country = "País 1" },
                new LocationDto { Id = Guid.NewGuid(), City = "Ciudad 2", Country = "País 2" }
            };
            var handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<System.Threading.CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(locations)
                });
            var httpClient = new HttpClient(handler.Object)
            {
                BaseAddress = new Uri("http://localhost/")
            };
            var service = new LocationService(httpClient);

            // Act
            var result = await service.GetLocationsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<LocationDto>)result).Count);
        }

        [Fact]
        public async Task GetLocationByIdAsync_ReturnsNull_WhenNotFound()
        {
            // Arrange
            var handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<System.Threading.CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound
                });
            var httpClient = new HttpClient(handler.Object)
            {
                BaseAddress = new Uri("http://localhost/")
            };
            var service = new LocationService(httpClient);

            // Act
            var result = await service.GetLocationByIdAsync(Guid.NewGuid());

            // Assert
            Assert.Null(result);
        }
    }
}
