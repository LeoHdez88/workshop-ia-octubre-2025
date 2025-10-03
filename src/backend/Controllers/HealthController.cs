using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly Services.ICompanyService companyService;
        private readonly Services.IIndustryService industryService;
        private readonly Services.ILocationService locationService;

        public HealthController(
            Services.ICompanyService companyService,
            Services.IIndustryService industryService,
            Services.ILocationService locationService)
        {
            this.companyService = companyService;
            this.industryService = industryService;
            this.locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var health = new Dictionary<string, string>();
            try
            {
                await companyService.GetAllAsync(null, null, null);
                health["Company"] = "Healthy";
            }
            catch { health["Company"] = "Error"; }
            try
            {
                await industryService.GetAllAsync();
                health["Industry"] = "Healthy";
            }
            catch { health["Industry"] = "Error"; }
            try
            {
                await locationService.GetAllAsync();
                health["Location"] = "Healthy";
            }
            catch { health["Location"] = "Error"; }
            return Ok(health);
        }
    }
}
