using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class IndustryRepository : IIndustryRepository
    {
        private readonly AppDbContext dbContext;
        public IndustryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // TODO: Implementar métodos de acceso a datos

        public async Task<List<Models.Industry>> GetAllAsync()
        {
            return await dbContext.Set<Models.Industry>().ToListAsync();
        }
    }
}
