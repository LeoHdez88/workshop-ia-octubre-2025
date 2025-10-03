using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Frontend.DTOs;

namespace Frontend.Services
{
    /// <summary>
    /// Implementación del servicio de ubicaciones para el frontend.
    /// </summary>
    public class LocationService : ILocationService
    {
        private readonly HttpClient httpClient;
        private const string LocationsEndpoint = "api/location";

        public LocationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<LocationDto>> GetLocationsAsync()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<LocationDto>>(LocationsEndpoint);
            return result ?? new List<LocationDto>();
        }

        public async Task<LocationDto?> GetLocationByIdAsync(Guid id)
        {
            var url = $"{LocationsEndpoint}/{id}";
            return await httpClient.GetFromJsonAsync<LocationDto>(url);
        }
    }
}
