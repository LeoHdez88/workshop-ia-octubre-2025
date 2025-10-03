using backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly backend.Data.AppDbContext dbContext;
        public CompanyService(ICompanyRepository companyRepository, backend.Data.AppDbContext dbContext)
        {
            this.companyRepository = companyRepository;
            this.dbContext = dbContext;
        }
        // TODO: Implementar lógica de negocio

        public async Task<List<DTOs.CompanyDto>> GetAllAsync(long? industryId, long? locationId, string? name)
        {
            var companies = await companyRepository.GetAllAsync(industryId, locationId, name);
            var industryIds = companies.Select(c => c.IndustryId).Distinct().ToList();
            var locationIds = companies.Select(c => c.LocationId).Distinct().ToList();
            var industries = await dbContext.Industries.Where(i => industryIds.Contains(i.Id)).ToDictionaryAsync(i => i.Id, i => i.Name);
            var locations = await dbContext.Locations.Where(l => locationIds.Contains(l.Id)).ToDictionaryAsync(l => l.Id, l => l.City + ", " + l.Country);
            return companies.Select(c => {
                var industryName = industries.ContainsKey(c.IndustryId) ? industries[c.IndustryId] : "";
                var locationName = locations.ContainsKey(c.LocationId) ? locations[c.LocationId] : "";
                return DTOs.Mappings.ToDto(c, industryName, locationName);
            }).ToList();
        }
    }
}
