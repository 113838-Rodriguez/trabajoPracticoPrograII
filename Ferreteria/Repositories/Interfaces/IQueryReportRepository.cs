using Ferreteria.DTOs;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IQueryReportRepository
    {
        ////==========================================Consultas de BD==========================================
        //PABLO: 1 [Productos sin Ventas en los Últimos N Días y su Capital Inmovilizado]
        Task<List<QRProductosSinVentasDTO>> GetProductosSinVentas(int dias);

        //MAXI: 2 [Consulta de Stock de Productos por Sucursal]        
        Task<List<QRStockbySucursalDTO>> GetStockbySucursal(string codigoProducto);

        //PABLO: 3 [Reporte de ventas mensuales por empleado y sucursal]
        Task<List<QREmpleadosySucursalesDTO>> GetEmpleadosySucursales(int? anio, int? sucursalID, int? empleadoId);

        //MAXI: 4 [Facturación por Tipo de Cliente en un Período Determinado]
        Task<List<QRFacturacionTipoClienteDTO>> GetFacturacionTipoCliente(DateTime fechaDesde, DateTime fechaHasta);
        
        //PABLO: 5 [Consulta de entregas atrasadas de pedidos y reposiciones]        
        Task<List<QREntregasAtrasadasDTO>> GetEntregasAtrasadas(DateOnly fechaReferencia);        
        //MAXI: 6 [Detección de Stock Mínimo y Reposición con Filtro de Ventas]
        Task<List<QRStockMinWithFilterDTO>> GetStockMinWithFilter(string? nombreSucursal);
        //===================================================================================================
    }
}