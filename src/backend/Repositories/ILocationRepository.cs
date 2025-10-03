namespace backend.Repositories
{
    public interface ILocationRepository
    {
        // TODO: Definir métodos de acceso a datos para Location
        Task<List<Models.Location>> GetAllAsync();
    }
}
