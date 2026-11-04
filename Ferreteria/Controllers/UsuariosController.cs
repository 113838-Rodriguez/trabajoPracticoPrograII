
using Ferreteria.DTOs;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);

            if (usuario == null)
                return NotFound("El usuario no existe");

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CreateUsuarioDTO dto)
        {
            try
            {
                await _usuarioService.CrearUsuarioAsync(dto);
                return StatusCode(201, "Usuario creado correctamente");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(
            int id, UpdateUsuarioDTO dto)
        {
            try
            {
                bool resultado =
                    await _usuarioService.ModificarUsuarioAsync(id, dto);

                if (!resultado)
                    return NotFound("El usuario no existe");

                return Ok("Usuario modificado correctamente");
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
                bool resultado =
                    await _usuarioService.EliminarUsuarioAsync(id);

                if (!resultado)
                    return NotFound("El usuario no existe");

                return Ok("Usuario desactivado correctamente");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
