using Ferreteria.DTOs;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Vendedor")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("Preguntar")]
        public async Task<IActionResult> Preguntar(
            [FromBody] ChatPreguntaDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Pregunta))
            {
                return BadRequest(new
                {
                    message = "La pregunta es obligatoria"
                });
            }

            string respuesta =
                await _chatService.PreguntarAsync(dto.Pregunta);

            return Ok(new
            {
                respuesta
            });
        }
    }
}