
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [ApiController]
    [Route("api/provincias")]
    public class UbicacionesController(IUbicacionService service) : ControllerBase
    {
        private readonly IUbicacionService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetProvincias()
        {
            return Ok(await _service.GetProvinciasAsync());
        }

        [HttpGet("{provinciaId}/ciudades")]
        public async Task<IActionResult> GetCiudades(int provinciaId)
        {
            try
            {
                return Ok(await _service.GetCiudadesAsync(provinciaId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("ciudades/{ciudadId}/barrios")]
        public async Task<IActionResult> GetBarrios(int ciudadId)
        {
            try
            {
                return Ok(await _service.GetBarriosAsync(ciudadId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("domicilios/{domicilioId}")]
        public async Task<IActionResult> GetDomicilio(int domicilioId)
        {
            try
            {
                var domicilio =
                    await _service.GetDomicilioByIdAsync(domicilioId);

                return domicilio == null
                    ? NotFound(new { message = "No se encontró el domicilio." })
                    : Ok(domicilio);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}