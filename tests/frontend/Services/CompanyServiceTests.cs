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
    public class CompanyServiceTests
    {
        [Fact]
        public async Task GetCompaniesAsync_ReturnsCompanies_WhenApiReturnsData()
        {
            // Arrange
            var companies = new List<CompanyDto>
            {
                new CompanyDto { Id = Guid.NewGuid(), Name = "Empresa 1" },
                new CompanyDto { Id = Guid.NewGuid(), Name = "Empresa 2" }
            };
            var handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<System.Threading.CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(companies)
                });
            var httpClient = new HttpClient(handler.Object)
            {
                BaseAddress = new Uri("http://localhost/")
            };
            var service = new CompanyService(httpClient);

            // Act
            var result = await service.GetCompaniesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<CompanyDto>)result).Count);
        }

        [Fact]
        public async Task GetCompanyByIdAsync_ReturnsNull_WhenNotFound()
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
            var service = new CompanyService(httpClient);

            // Act
            var result = await service.GetCompanyByIdAsync(Guid.NewGuid());

            // Assert
            Assert.Null(result);
        }
    }
}
