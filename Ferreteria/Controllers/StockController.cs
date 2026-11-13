using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // SIN [AUTHORIZE] POR EL MOMENTO
    public class StockController : ControllerBase
    {
        private readonly IStockService _service;

        public StockController(IStockService service)
        {
            _service = service;
        }

        // Registros de todas las sucursales
        // Opcional: Filtrar por Sucursal o Codigo de prod
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int? sucursalId = null,
            [FromQuery] string? codigoParcial = null,
            [FromQuery] bool soloBajoMinimo = false)
        {
            try
            {
                var stocks = await _service.GetAllAsync(
                    sucursalId, codigoParcial, soloBajoMinimo);

                return Ok(stocks);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Registros con cantidad inferior al mínimo
        [HttpGet("bajo-minimo")]
        public async Task<IActionResult> GetBajoMinimo(
            [FromQuery] int? sucursalId = null)
        {
            try
            {
                var stocks = await _service.GetAllAsync(
                    sucursalId, null, true);

                return Ok(stocks);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Registro de stock por ID (endpoint usado por otras capas)
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock = await _service.GetByIdAsync(id);

            if (stock == null)
                return NotFound("Registro de stock no encontrado.");

            return Ok(stock);
        }
    }
}
