using Ferreteria.Models;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [Controller]
    [Route("ferreteria/ubicacion")]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionService _ubicacionService;

        public UbicacionController(IUbicacionService service)
        {
            _ubicacionService = service;
        }

        [HttpGet]
        [Route("provincias")]

        public IActionResult GetProvincias()
        {
            try
            {
               IEnumerable<Provincia> provincia =  _ubicacionService.GetProvincias();

                if(provincia == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(provincia);
                }

            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
