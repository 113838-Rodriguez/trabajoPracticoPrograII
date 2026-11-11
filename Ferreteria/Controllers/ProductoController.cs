using Ferreteria.DTOs;
using Ferreteria.Services;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Ferreteria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        // CONSULTAR TODOS LOS PRODUCTOS ACTIVOS
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] bool traerInactivos = false)
        {
            //if (traerInactivos && !User.IsInRole("admin"))
            //   return Forbid();

            var productos = await _service.GetAllAsync(traerInactivos);

            return Ok(productos);
        }

        // CONSULTAR POR ID
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] bool incluirInactivos = false)
        {
            var producto = await _service.GetByIdAsync(id, incluirInactivos);

            if (producto == null)
            {
                return NotFound("Producto no encontrado.");
            }

            if (!producto.Activo && !User.IsInRole("admin"))
            {
                return Forbid();
            }

            return Ok(producto);
        }

        // CONSULTAR POR CODIGO
        [HttpGet]
        [Route("codigo/{codigo}")]

        public async Task<IActionResult> GetByCodigo(
    string codigo, [FromQuery] bool incluirInactivos = false)
        {
            try
            {
                var producto = await _service.GetByCodigoAsync(
                    codigo, incluirInactivos);

                if (producto == null)
                {
                    return NotFound("Producto no encontrado.");
                }
                if (!producto.Activo && !User.IsInRole("admin"))
                {
                    return Forbid();
                }

                return Ok(producto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ALTA DE PRODUCTO
        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] ProductoRequestDTO dto)
        {
            try
            {
                var producto = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetByCodigo), new { codigo = producto.Codigo }, producto);
            }
            // Excepcion datos invalidos
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            // Excepcion codigo duplicado
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // MODIFICACION DE PRODUCTO
        [HttpPut("codigo/{codigo}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string codigo, [FromBody] ProductoRequestDTO dto)
        {
            try
            {
                var producto = await _service.UpdateAsync(codigo, dto);

                if (producto == null)
                    return NotFound("El producto no existe o está inactivo.");

                return Ok(producto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // BAJA DE PRODUCTO
        [HttpDelete("codigo/{codigo}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Eliminar(string codigo)
        {
            try
            {
                bool resultado = await _service.DeleteAsync(codigo);

                if (!resultado)
                    return NotFound("El producto no existe o ya está inactivo.");

                return Ok("Producto desactivado correctamente.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // REACTIVACION DE PRODUCTO
        [HttpPatch("codigo/{codigo}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reactivar(string codigo)
        {
            try
            {
                bool resultado =
                    await _service.ReactivarProductoAsync(codigo);

                if (!resultado)
                    return NotFound("El producto no existe o ya está activo.");

                return Ok("Producto reactivado correctamente.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // CONSULTAR CATEGORIAS DE PRODUCTOS
        [HttpGet("categorias")]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _service.GetCategoriasAsync();

            return Ok(categorias);
        }

        // CONSULTAR TIPOS DE PRODUCTOS
        [HttpGet("tipos")]
        public async Task<IActionResult> GetTipos()
        {
            var tipos = await _service.GetTiposAsync();

            return Ok(tipos);
        }






    }
}
