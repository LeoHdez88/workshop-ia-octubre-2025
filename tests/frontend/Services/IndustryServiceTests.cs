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
    public class IndustryServiceTests
    {
        [Fact]
        public async Task GetIndustriesAsync_ReturnsIndustries_WhenApiReturnsData()
        {
            // Arrange
            var industries = new List<IndustryDto>
            {
                new IndustryDto { Id = Guid.NewGuid(), Name = "Industria 1" },
                new IndustryDto { Id = Guid.NewGuid(), Name = "Industria 2" }
            };
            var handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<System.Threading.CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(industries)
                });
            var httpClient = new HttpClient(handler.Object)
            {
                BaseAddress = new Uri("http://localhost/")
            };
            var service = new IndustryService(httpClient);

            // Act
            var result = await service.GetIndustriesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<IndustryDto>)result).Count);
        }

        [Fact]
        public async Task GetIndustryByIdAsync_ReturnsNull_WhenNotFound()
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
            var service = new IndustryService(httpClient);

            // Act
            var result = await service.GetIndustryByIdAsync(Guid.NewGuid());

            // Assert
            Assert.Null(result);
        }
    }
}
