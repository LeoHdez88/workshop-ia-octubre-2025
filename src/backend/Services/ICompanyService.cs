namespace backend.Services
{
    public interface ICompanyService
    {
        // TODO: Definir métodos de negocio para Company
    Task<List<DTOs.CompanyDto>> GetAllAsync(long? industryId, long? locationId, string? name);
    }
}
