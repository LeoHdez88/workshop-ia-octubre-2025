
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Frontend.DTOs;

namespace Frontend.Services
{
    /// <summary>
    /// Servicio para operaciones de ubicaciones en el frontend.
    /// </summary>
    public interface ILocationService
    {
        Task<IEnumerable<LocationDto>> GetLocationsAsync();
        Task<LocationDto?> GetLocationByIdAsync(Guid id);
    }
}
