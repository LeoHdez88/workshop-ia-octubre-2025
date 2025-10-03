using backend.Repositories;

namespace backend.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        // TODO: Implementar lógica de negocio

        public async Task<List<DTOs.LocationDto>> GetAllAsync()
        {
            var locations = await locationRepository.GetAllAsync();
            return locations.Select(DTOs.Mappings.ToDto).ToList();
        }
    }
}
