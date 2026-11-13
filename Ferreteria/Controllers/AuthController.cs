
using Ferreteria.DTOs;
using Ferreteria.Services;
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
        private readonly NfcLoginService _nfcLoginService;
        public AuthController(IAuthService authService, NfcLoginService nfcLoginService)
        {
            _authService = authService;
            _nfcLoginService = nfcLoginService;
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

        [HttpPost("NFC/Iniciar")]
        [AllowAnonymous]
        public IActionResult IniciarNfc()
        {
            string solicitud = _nfcLoginService.Iniciar();

            string[] partes = solicitud.Split(':', 2);

            return Ok(new
            {
                solicitudId = partes[0],
                claveConsulta = partes[1],
                expiraEnSegundos = 120
            });
        }

        [HttpPost("NFC/Autorizar")]
        [AllowAnonymous]
        public async Task<IActionResult> AutorizarNfc(
            [FromBody] AutorizarNfcDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SolicitudId))
                return BadRequest(new { message = "Solicitud requerida" });

            string? token = await _authService.LoginAsync(
                new LoginDTO
                {
                    NombreUsuario = dto.NombreUsuario,
                    Password = dto.Password
                });

            if (token == null)
                return Unauthorized(new
                {
                    message = "Credenciales incorrectas"
                });

            bool autorizado = _nfcLoginService.Autorizar(
                dto.SolicitudId, token);

            if (!autorizado)
                return BadRequest(new
                {
                    message = "Solicitud inexistente, vencida o ya autorizada"
                });

            return Ok(new
            {
                message = "Inicio de sesión NFC autorizado"
            });
        }

        [HttpGet("NFC/Estado/{id}")]
        [AllowAnonymous]
        public IActionResult EstadoNfc(
            string id,
            [FromQuery] string clave)
        {
            string? token = _nfcLoginService.ObtenerToken(id, clave);

            if (token == null)
                return Ok(new { autorizado = false });

            return Ok(new
            {
                autorizado = true,
                token
            });
        }


        [HttpPost("NFC/AutorizarDemo")]
        [AllowAnonymous]
        public async Task<IActionResult> AutorizarNfcDemo([FromBody] LoginDTO dto)

        {
            string? token = await _authService.LoginAsync(dto);

            if (token == null)
            {
                return Unauthorized(new
                {
                    message = "Usuario o contraseña incorrectos"
                });
            }

            bool autorizado =
                _nfcLoginService.AutorizarUnicaPendiente(token);

            if (!autorizado)
            {
                return Conflict(new
                {
                    message = "Debe existir una única PC esperando NFC"
                });
            }

            return Ok(new
            {
                message = "Login NFC autorizado correctamente"
            });
        }
    }
}
