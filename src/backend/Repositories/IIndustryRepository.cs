namespace backend.Repositories
{
    public interface IIndustryRepository
    {
        // TODO: Definir métodos de acceso a datos para Industry
        Task<List<Models.Industry>> GetAllAsync();
    }
}
