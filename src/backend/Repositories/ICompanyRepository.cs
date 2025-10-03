namespace backend.Repositories
{
    public interface ICompanyRepository
    {
        // TODO: Definir métodos de acceso a datos para Company
    Task<List<Models.Company>> GetAllAsync(long? industryId, long? locationId, string? name);
    }
}
