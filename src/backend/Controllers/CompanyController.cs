using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        // TODO: Implementar endpoints

        /// <summary>
        /// Obtiene el listado de empresas filtrando por industria, ubicación y nombre.
        /// </summary>
        /// <param name="industryId">Id de la industria</param>
        /// <param name="locationId">Id de la ubicación</param>
        /// <param name="name">Nombre de la empresa</param>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] long? industryId, [FromQuery] long? locationId, [FromQuery] string? name)
        {
            var result = await companyService.GetAllAsync(industryId, locationId, name);
            return Ok(result);
        }
    }
}
