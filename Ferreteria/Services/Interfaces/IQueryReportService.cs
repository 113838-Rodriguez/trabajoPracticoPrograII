using Ferreteria.DTOs;

namespace Ferreteria.Services.Interfaces
{
    public interface IQueryReportService
    {
        ////==========================================Consultas de BD==========================================
        //NRO DE CONSULTA: 1 [Productos sin Ventas en los Últimos N Días y su Capital Inmovilizado]
        //PABLO
        Task<List<QRProductosSinVentasDTO>> GetProductosSinVentas(int dias);

        //NRO DE CONSULTA: 2 [Consulta de Stock de Productos por Sucursal]
        //MAXI
        Task<List<QRStockbySucursalDTO>> GetStockbySucursal(string codigoProducto);

        //NRO DE CONSULTA: 3 [Reporte de ventas mensuales por empleado y sucursal]
        //PABLO
        Task<List<QREmpleadosySucursalesDTO>> GetEmpleadosySucursales(int? anio, int? sucursalID, int? empleadoId);


        //NRO DE CONSULTA: 4 [Facturación por Tipo de Cliente en un Período Determinado]
        //MAXI
        Task<List<QRFacturacionTipoClienteDTO>> GetFacturacionTipoCliente(DateTime? fechaDesde, DateTime? fechaHasta);

        //NRO DE CONSULTA: 5 [Consulta de entregas atrasadas de pedidos y reposiciones]
        //PABLO
        Task<List<QREntregasAtrasadasDTO>> GetEntregasAtrasadas(DateTime fechaReferencia);

        //NRO DE CONSULTA: 6 [Detección de Stock Mínimo y Reposición con Filtro de Ventas]
        //MAXI
        Task<List<QRStockMinWithFilterDTO>> GetStockMinWithFilter(string? nombreSucursal);
        //===================================================================================================
    }
}