using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConexionController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Probar()
        {
            return Ok(new
            {
                mensaje = "Conexion exitosa desde el iPhone",
                estado = "OK"
            });
        }
    }
}