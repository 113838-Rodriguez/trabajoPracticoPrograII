using Ferreteria.DTOs;
using Ferreteria.Services;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IQueryReportRepository
    {
        ////==========================================Consultas de BD==========================================
        //NRO DE CONSULTA: 1 [Productos sin Ventas en los Últimos N Días y su Capital Inmovilizado]
        //PABLO
        private List<QueryReportDTO1> GetProductosSinVentas()
        {
            throw new NotImplementedException();
        }

        //NRO DE CONSULTA: 2 [Consulta de Stock de Productos por Sucursal]
        //MAXI
        private List<QueryReportDTO2> GetStockbySucursal()
        {
            throw new NotImplementedException();
        }

        //NRO DE CONSULTA: 3 [Reporte de ventas mensuales por empleado y sucursal]
        //PABLO
        private List<QueryReportDTO3> GetEmpleadosySucursales()
        {
            throw new NotImplementedException();
        }

        //NRO DE CONSULTA: 4 [Facturación por Tipo de Cliente en un Período Determinado]
        //MAXI
        private List<QueryReportDTO4> GetFacturacionTipoCliente()
        {
            throw new NotImplementedException();
        }

        //NRO DE CONSULTA: 5 [Consulta de entregas atrasadas de pedidos y reposiciones]
        //PABLO
        private List<QueryReportDTO5> GetEntregasAtrasadas()
        {
            throw new NotImplementedException();
        }

        //NRO DE CONSULTA: 6 [Detección de Stock Mínimo y Reposición con Filtro de Ventas]
        //MAXI
        private List<QueryReportDTO6> GetStockMinWithFilter()
        {
            throw new NotImplementedException();
        }
        //===================================================================================================
    }
}