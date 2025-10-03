using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Frontend.DTOs;

namespace Frontend.Services
{
    /// <summary>
    /// Implementación del servicio de industrias para el frontend.
    /// </summary>
    public class IndustryService : IIndustryService
    {
        private readonly HttpClient httpClient;
        private const string IndustriesEndpoint = "api/industry";

        public IndustryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<IndustryDto>> GetIndustriesAsync()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<IndustryDto>>(IndustriesEndpoint);
            return result ?? new List<IndustryDto>();
        }

        public async Task<IndustryDto?> GetIndustryByIdAsync(Guid id)
        {
            var url = $"{IndustriesEndpoint}/{id}";
            return await httpClient.GetFromJsonAsync<IndustryDto>(url);
        }
    }
}
