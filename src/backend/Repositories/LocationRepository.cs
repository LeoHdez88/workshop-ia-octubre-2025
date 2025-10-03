using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext dbContext;
        public LocationRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // TODO: Implementar métodos de acceso a datos

        public async Task<List<Models.Location>> GetAllAsync()
        {
            return await dbContext.Set<Models.Location>().ToListAsync();
        }
    }
}
