using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using backend.Repositories;
using backend.Services;
using backend.DTOs;
using Moq;
using Xunit;

namespace backend.Tests.Services
{
    public class CompanyServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsExpectedCompanies()
        {
            // Arrange
            var companies = new List<Company>
            {
                new Company { Id = Guid.NewGuid(), Name = "A", IndustryId = Guid.NewGuid(), LocationId = Guid.NewGuid() },
                new Company { Id = Guid.NewGuid(), Name = "B", IndustryId = Guid.NewGuid(), LocationId = Guid.NewGuid() }
            };
            var repoMock = new Mock<ICompanyRepository>();
            repoMock.Setup(r => r.GetAllAsync(null, null, null)).ReturnsAsync(companies);
            var service = new CompanyService(repoMock.Object);

            // Act
            var result = await service.GetAllAsync(null, null, null);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, dto => Assert.False(string.IsNullOrWhiteSpace(dto.Name)));
        }

        [Fact]
        public async Task GetAllAsync_EmptyResult_ReturnsEmptyList()
        {
            var repoMock = new Mock<ICompanyRepository>();
            repoMock.Setup(r => r.GetAllAsync(It.IsAny<Guid?>(), It.IsAny<Guid?>(), It.IsAny<string?>())).ReturnsAsync(new List<Company>());
            var service = new CompanyService(repoMock.Object);
            var result = await service.GetAllAsync(null, null, null);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAllAsync_ThrowsException_ReturnsException()
        {
            var repoMock = new Mock<ICompanyRepository>();
            repoMock.Setup(r => r.GetAllAsync(It.IsAny<Guid?>(), It.IsAny<Guid?>(), It.IsAny<string?>())).ThrowsAsync(new Exception("DB error"));
            var service = new CompanyService(repoMock.Object);
            await Assert.ThrowsAsync<Exception>(() => service.GetAllAsync(null, null, null));
        }
    }
}
