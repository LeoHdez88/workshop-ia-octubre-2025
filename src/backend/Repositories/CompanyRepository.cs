using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext dbContext;
        public CompanyRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // TODO: Implementar métodos de acceso a datos

        public async Task<List<Models.Company>> GetAllAsync(long? industryId, long? locationId, string? name)
        {
            var query = dbContext.Companies.AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(c => c.Name.Contains(name));
            // Suponiendo que Company tiene IndustryId y LocationId
            if (industryId.HasValue)
                query = query.Where(c => EF.Property<long>(c, "IndustryId") == industryId.Value);
            if (locationId.HasValue)
                query = query.Where(c => EF.Property<long>(c, "LocationId") == locationId.Value);
            return await query.ToListAsync();
        }
    }
}
