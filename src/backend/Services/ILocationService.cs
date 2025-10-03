namespace backend.Services
{
    public interface ILocationService
    {
        // TODO: Definir métodos para obtener ubicaciones
        Task<List<DTOs.LocationDto>> GetAllAsync();
    }
}
