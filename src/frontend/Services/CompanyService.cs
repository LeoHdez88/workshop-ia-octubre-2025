using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Frontend.DTOs;

namespace Frontend.Services
{
    /// <summary>
    /// Implementación del servicio de empresas para el frontend.
    /// </summary>
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient httpClient;
        private const string CompaniesEndpoint = "api/company";

        public CompanyService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<CompanyDto>> GetCompaniesAsync(
            long? industryId = null,
            long? locationId = null,
            string? name = null,
            int page = 1,
            int pageSize = 20)
        {
            var url = $"{CompaniesEndpoint}?";
            var parameters = new List<string>();
            if (industryId.HasValue) parameters.Add($"industryId={industryId.Value}");
            if (locationId.HasValue) parameters.Add($"locationId={locationId.Value}");
            if (!string.IsNullOrWhiteSpace(name)) parameters.Add($"name={Uri.EscapeDataString(name)}");
            parameters.Add($"page={page}");
            parameters.Add($"pageSize={pageSize}");
            url += string.Join("&", parameters);
            var result = await httpClient.GetFromJsonAsync<IEnumerable<CompanyDto>>(url);
            return result ?? new List<CompanyDto>();
        }

        public async Task<CompanyDto?> GetCompanyByIdAsync(Guid id)
        {
            var url = $"{CompaniesEndpoint}/{id}";
            return await httpClient.GetFromJsonAsync<CompanyDto>(url);
        }
    }
}
