using backend.Repositories;

namespace backend.Services
{
    public class IndustryService : IIndustryService
    {
        private readonly IIndustryRepository industryRepository;
        public IndustryService(IIndustryRepository industryRepository)
        {
            this.industryRepository = industryRepository;
        }
        // TODO: Implementar lógica de negocio

        public async Task<List<DTOs.IndustryDto>> GetAllAsync()
        {
            var industries = await industryRepository.GetAllAsync();
            return industries.Select(DTOs.Mappings.ToDto).ToList();
        }
    }
}
