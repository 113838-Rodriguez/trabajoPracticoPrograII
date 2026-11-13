
using Ferreteria.Models;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empleados = await _empleadoService.GetAllAsync();

            return Ok(empleados);
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empleado = await _empleadoService.GetByIdAsync(id);

            if (empleado == null)
            {
                return NotFound("El empleado no existe");
            }

            return Ok(empleado);
        }

        // POST: api/Empleados
        [HttpPost]
        public async Task<IActionResult> Crear(CreateEmpleadoDTO dto)
        {
            try
            {
                int empleadoId =
                    await _empleadoService.CrearEmpleadoAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = empleadoId },
                    new
                    {
                        mensaje = "Empleado creado correctamente",
                        empleadoId = empleadoId
                    }
                );
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                bool resultado = await _empleadoService.EliminarEmpleadoAsync(id);

                if (!resultado)
                {
                    return NotFound("El empleado no existe");
                }

                return Ok("Empleado eliminado correctamente");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
