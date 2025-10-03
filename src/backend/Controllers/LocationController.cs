using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;
        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }
        // TODO: Implementar endpoints de ubicaciones
            /// <summary>
            /// Obtiene el listado de ubicaciones.
            /// </summary>
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await locationService.GetAllAsync();
                return Ok(result);
            }
    }
}
