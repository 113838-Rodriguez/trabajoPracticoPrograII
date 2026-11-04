
using Ferreteria.DTOs;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                string? token = await _authService.LoginAsync(dto);

                if (token == null)
                {
                    return Unauthorized(new
                    {
                        message = "Usuario o contraseña incorrectos"
                    });
                }

                return Ok(new
                {
                    message = "Inicio de sesión exitoso",
                    token = token
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Error interno del servidor"
                });
            }
        }


       
    }
}
