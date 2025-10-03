
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Frontend.DTOs;

namespace Frontend.Services
{
    /// <summary>
    /// Servicio para operaciones de empresas en el frontend.
    /// </summary>
    public interface ICompanyService
    {
    Task<IEnumerable<CompanyDto>> GetCompaniesAsync(long? industryId = null, long? locationId = null, string? name = null, int page = 1, int pageSize = 20);
        Task<CompanyDto?> GetCompanyByIdAsync(Guid id);
    }
}
