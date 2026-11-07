using Ferreteria.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    [ApiController]
    [Route("api/queryreport")]
    public class QueryReportController(IQueryReportRepository repo) : ControllerBase
    {
        private readonly IQueryReportRepository _repo = repo;

        ////==========================================Consultas de BD==========================================
        //NRO DE CONSULTA: 1 [Productos sin Ventas en los Últimos N Días y su Capital Inmovilizado]
        //PABLO
        [HttpGet]
        private IActionResult GetProductosSinVentas()
        {
            throw new NotImplementedException();
        }

        //NRO DE CONSULTA: 2 [Consulta de Stock de Productos por Sucursal]
        //MAXI
        [HttpGet]
        private IActionResult GetStockbySucursal()
        {
            throw new NotImplementedException();
        }

        //NRO DE CONSULTA: 3 [Reporte de ventas mensuales por empleado y sucursal]
        //PABLO
        [HttpGet]
        private IActionResult GetEmpleadosySucursales()
        {
            throw new NotImplementedException();
        }

        //NRO DE CONSULTA: 4 [Facturación por Tipo de Cliente en un Período Determinado]
        //MAXI
        [HttpGet]
        private IActionResult GetFacturacionTipoCliente()
        {
            throw new NotImplementedException();
        }

        //NRO DE CONSULTA: 5 [Consulta de entregas atrasadas de pedidos y reposiciones]
        //PABLO
        [HttpGet]
        private IActionResult GetEntregasAtrasadas()
        {
            throw new NotImplementedException();
        }

        //NRO DE CONSULTA: 6 [Detección de Stock Mínimo y Reposición con Filtro de Ventas]
        //MAXI
        [HttpGet]
        private IActionResult GetStockMinWithFilter()
        {
            throw new NotImplementedException();
        }
        //===================================================================================================
    }
}