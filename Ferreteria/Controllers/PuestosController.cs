
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class PuestosController : ControllerBase
    {
        private readonly IPuestoService _puestoService;

        public PuestosController(IPuestoService puestoService)
        {
            _puestoService = puestoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var puestos = await _puestoService.GetAllAsync();

            return Ok(puestos);
        }
    }
}
