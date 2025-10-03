namespace backend.Services
{
    public interface IIndustryService
    {
        // TODO: Definir métodos para obtener industrias
        Task<List<DTOs.IndustryDto>> GetAllAsync();
    }
}
