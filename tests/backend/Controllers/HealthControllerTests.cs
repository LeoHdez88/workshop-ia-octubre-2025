using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using src.backend.Controllers;
using src.backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class HealthControllerTests
    {
        [Fact]
        public async Task Get_ReturnsHealthyStatus_WhenAllServicesWork()
        {
            // Arrange
            var companyService = new Mock<ICompanyService>();
            var industryService = new Mock<IIndustryService>();
            var locationService = new Mock<ILocationService>();
            companyService.Setup(s => s.GetAllAsync(null, null, null)).ReturnsAsync(new List<DTOs.CompanyReadDto>());
            industryService.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<DTOs.IndustryReadDto>());
            locationService.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<DTOs.LocationReadDto>());
            var controller = new HealthController(companyService.Object, industryService.Object, locationService.Object);

            // Act
            var result = await controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var health = Assert.IsType<Dictionary<string, string>>(okResult.Value);

            // Assert
            Assert.Equal("Healthy", health["Company"]);
            Assert.Equal("Healthy", health["Industry"]);
            Assert.Equal("Healthy", health["Location"]);
        }

        [Fact]
        public async Task Get_ReturnsErrorStatus_WhenAServiceThrows()
        {
            // Arrange
            var companyService = new Mock<ICompanyService>();
            var industryService = new Mock<IIndustryService>();
            var locationService = new Mock<ILocationService>();
            companyService.Setup(s => s.GetAllAsync(null, null, null)).ThrowsAsync(new System.Exception());
            industryService.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<DTOs.IndustryReadDto>());
            locationService.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<DTOs.LocationReadDto>());
            var controller = new HealthController(companyService.Object, industryService.Object, locationService.Object);

            // Act
            var result = await controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var health = Assert.IsType<Dictionary<string, string>>(okResult.Value);

            // Assert
            Assert.Equal("Error", health["Company"]);
            Assert.Equal("Healthy", health["Industry"]);
            Assert.Equal("Healthy", health["Location"]);
        }
    }
}
