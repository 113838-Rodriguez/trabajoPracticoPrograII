using Ferreteria.DTOs;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController(IClienteService clienteService) : ControllerBase
    {
        private readonly IClienteService _clienteService = clienteService;

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "El ID debe ser mayor a cero." });

            var cliente = await _clienteService.GetByIdAsync(id);

            if (cliente == null)
                return NotFound(new { message = "No se encontró el cliente." });

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDTO dto)
        {
            try
            {
                await _clienteService.CrearClienteAsync(dto);

                return StatusCode(201, new { message = "Cliente creado exitosamente." });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDTO dto)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { message = "El ID no es válido." });

                var resultado = await _clienteService.ModificarClienteAsync(id, dto);

                if (!resultado)
                    return NotFound(new { message = "No se encontró el cliente." });

                return Ok(new { message = "Cliente modificado correctamente." });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "El ID no es válido." });

            var resultado = await _clienteService.EliminarClienteAsync(id);

            if (!resultado)
                return NotFound(new { message = "No se encontró el cliente." });

            return Ok(new { message = "Cliente dado de baja correctamente." });
        }

        [HttpGet("inactivos")]
        public async Task<IActionResult> GetInactivos()
        {
            var clientes = await _clienteService.GetInactivosAsync();
            return Ok(clientes);
        }

        [HttpPost("reactivar")]
        public async Task<IActionResult> Reactivar([FromBody] ReactivarClienteDTO dto)
        {
            try
            {
                await _clienteService.ReactivarClienteAsync(dto.Dni);

                return Ok(new { message = "Cliente reactivado correctamente." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //TipoController
        [HttpGet("tipo")]
        public async Task<IActionResult> GetTipoClienteAll()
        {
            var tipos = await _clienteService.GetTipoClienteAllAsync();

            return Ok(tipos);
        }

        [HttpGet("tipo/{id}")]
        public async Task<IActionResult> GetTipoClienteById(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "El ID debe ser mayor a cero." });

            var tipo = await _clienteService.GetTipoClienteByIdAsync(id);

            if (tipo == null)
                return NotFound(new { message = "No se encontró el tipo de cliente." });

            return Ok(tipo);
        }
    }
}
