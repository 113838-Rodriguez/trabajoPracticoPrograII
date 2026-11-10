using Ferreteria.DTOs;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
                return NotFound(new { message = "El cliente no existe" });

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteDTO dto)
        {
            try
            {
                await _clienteService.CrearClienteAsync(dto);
                return Ok(new { message = "Cliente creado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClienteDTO dto)
        {
            try
            {
                var resultado = await _clienteService.ModificarClienteAsync(id, dto);
                if (!resultado)
                    return NotFound(new { message = "El cliente no existe" });

                return Ok(new { message = "Cliente modificado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _clienteService.EliminarClienteAsync(id);
            if (!resultado)
                return NotFound(new { message = "El cliente no existe" });

            return Ok(new { message = "Cliente eliminado correctamente" });
        }
    }
}
