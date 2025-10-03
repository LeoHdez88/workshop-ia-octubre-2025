using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndustryController : ControllerBase
    {
        private readonly IIndustryService industryService;
        public IndustryController(IIndustryService industryService)
        {
            this.industryService = industryService;
        }
        // TODO: Implementar endpoints de industrias
            /// <summary>
            /// Obtiene el listado de industrias.
            /// </summary>
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await industryService.GetAllAsync();
                return Ok(result);
            }
    }
}
