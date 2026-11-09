using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class QueryReportController(IQueryReportService service) : ControllerBase
    {
        private readonly IQueryReportService _service = service;

        ////==========================================Consultas de BD==========================================
        //NRO DE CONSULTA: 1 [Productos sin Ventas en los Últimos N Días y su Capital Inmovilizado]
        //PABLO
        [HttpGet("productos-sin-ventas/{dias}")]
        public async Task<IActionResult> GetProductosSinVentas([FromRoute] int dias)
        {
            try
            {
                var resultado = await _service.GetProductosSinVentas(dias);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });

            }
        }

        //NRO DE CONSULTA: 2 [Consulta de Stock de Productos por Sucursal]
        //MAXI
        [HttpGet("stock-sucursal/{codigoProducto}")]
        public async Task<IActionResult> GetStockbySucursal(string codigoProducto)
        {
            try
            {
                var resultado = await _service.GetStockbySucursal(codigoProducto);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });

            }
            catch (SqlException ex) when (ex.Number == 50000)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        //NRO DE CONSULTA: 3 [Reporte de ventas mensuales por empleado y sucursal]
        //PABLO
        [HttpGet("empleados-sucursales")]
        public async Task<IActionResult> GetEmpleadosySucursales([FromQuery] int? anio,[FromQuery] int? sucursalID,[FromQuery] int? empleadoId)
        {
            try
            {
                var resultado = await _service.GetEmpleadosySucursales(anio, sucursalID, empleadoId);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        //NRO DE CONSULTA: 4 [Facturación por Tipo de Cliente en un Período Determinado]
        //MAXI
        [HttpGet("facturacion-tipo-cliente")]
        public async Task<IActionResult> GetFacturacionTipoCliente([FromQuery] DateTime? fechaDesde, [FromQuery] DateTime? fechaHasta)
        {
            try
            {
                var resultado = await _service.GetFacturacionTipoCliente(fechaDesde, fechaHasta);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        //NRO DE CONSULTA: 5 [Consulta de entregas atrasadas de pedidos y reposiciones]
        //PABLO
        [HttpGet("entregas-atrasadas")]
        public async Task<IActionResult> GetEntregasAtrasadas([FromQuery] DateOnly fechaReferencia)
        {
            try
            {
                var resultado = await _service.GetEntregasAtrasadas(fechaReferencia);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        //NRO DE CONSULTA: 6 [Detección de Stock Mínimo y Reposición con Filtro de Ventas]
        //MAXI
        [HttpGet("stock-minimo")]
        public async Task<IActionResult> GetStockMinWithFilter([FromQuery] string? nombreSucursal)
        {
            var resultado = await _service.GetStockMinWithFilter(nombreSucursal);
            return Ok(resultado);
        }
        //===================================================================================================
    }
}