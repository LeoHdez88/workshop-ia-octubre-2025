
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Frontend.DTOs;

namespace Frontend.Services
{
    /// <summary>
    /// Servicio para operaciones de industrias en el frontend.
    /// </summary>
    public interface IIndustryService
    {
        Task<IEnumerable<IndustryDto>> GetIndustriesAsync();
        Task<IndustryDto?> GetIndustryByIdAsync(Guid id);
    }
}
