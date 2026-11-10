using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.DTOs;

namespace Ferreteria.Repositories
{
    public class QueryReportRepository(FerreteriaContext db) : IQueryReportRepository
    {
        public readonly FerreteriaContext _db = db;

        //Q1.Pablo
        public async Task<List<QRProductosSinVentasDTO>> GetProductosSinVentas(int dias)
        {
            var pDias = new SqlParameter("@Dias", SqlDbType.Int) { Value = dias };

            return await _db.Database.SqlQueryRaw<QRProductosSinVentasDTO>(
                "EXEC sp_ProductosSinVentas @Dias", pDias)
                .ToListAsync();
        }

        //Q2.Maxi
        public async Task<List<QRStockbySucursalDTO>> GetStockbySucursal(string codigoProducto)
        {
            var pCodigo = new SqlParameter("@CodigoProducto", SqlDbType.VarChar, 30) { Value = codigoProducto };

            return await _db.Database.SqlQueryRaw<QRStockbySucursalDTO>(
                "EXEC SP_ObtenerStockProductoPorSucursal @CodigoProducto", pCodigo)
                .ToListAsync();
        }

        //Q3.Pablo
        public async Task<List<SucursalComboDTO>> GetSucursales()
        {
            return await _db.Database.SqlQueryRaw<SucursalComboDTO>(
                @"SELECT Descripcion FROM SUCURSALES ORDER BY Descripcion")
                .ToListAsync();
        }

        public async Task<List<EmpleadoComboDTO>> GetEmpleadosPorSucursal(int sucursalID)
        {
            var pSucursalID = new SqlParameter("@SucursalID", SqlDbType.Int) { Value = sucursalID };

            return await _db.Database .SqlQueryRaw<EmpleadoComboDTO>(
                @"SELECT CONCAT(Apellido, ', ', Nombre) 'Nombre' FROM EMPLEADOS WHERE SucursalID = @SucursalID ORDER BY Apellido, Nombre", pSucursalID)
                .ToListAsync();
        }

        public async Task<List<QREmpleadosySucursalesDTO>> GetEmpleadosySucursales(int? anio, int? sucursalID, int? empleadoId)
        {
            var pAnio = new SqlParameter("@Anio", SqlDbType.Int) { Value = anio as object ?? DBNull.Value };
            var pSucursalID = new SqlParameter("@SucursalID", SqlDbType.Int) { Value = sucursalID as object ?? DBNull.Value };
            var pEmpleadoId = new SqlParameter("@EmpleadoID", SqlDbType.Int) { Value = empleadoId as object ?? DBNull.Value };

            return await _db.Database.SqlQueryRaw<QREmpleadosySucursalesDTO>(
                "EXEC sp_VentasMensualesEmpleadosPorSucursal @Anio, @SucursalID, @EmpleadoID", pAnio, pSucursalID, pEmpleadoId)
                .ToListAsync();
        }

        //Q4.Maxi
        public async Task<List<QRFacturacionTipoClienteDTO>> GetFacturacionTipoCliente(DateTime fechaDesde, DateTime fechaHasta)
        {
            var pDesde = new SqlParameter("@FechaDesde", SqlDbType.Date) { Value = fechaDesde.Date };
            var pHasta = new SqlParameter("@FechaHasta", SqlDbType.Date) { Value = fechaHasta.Date };

            return await _db.Database.SqlQueryRaw<QRFacturacionTipoClienteDTO>(
                "EXEC sp_VentasPorTipoCliente @FechaDesde, @FechaHasta", pDesde, pHasta)
                .ToListAsync();
        }

        //Q5.Pablo
        public async Task<List<QREntregasAtrasadasDTO>> GetEntregasAtrasadas(DateOnly fechaReferencia)
        {
            var pFecha = new SqlParameter("@FechaReferencia", SqlDbType.Date) { Value = fechaReferencia.ToDateTime(TimeOnly.MinValue) };

            return await _db.Database.SqlQueryRaw<QREntregasAtrasadasDTO>(
                "EXEC sp_EntregasAtrasadas @FechaReferencia", pFecha)
                .ToListAsync();
        }


        //Q6.Maxi
        public async Task<List<QRStockMinWithFilterDTO>> GetStockMinWithFilter(string? nombreSucursal)
        {
            var pSucursal = new SqlParameter("@NombreSucursal", SqlDbType.VarChar, 100) { Value = nombreSucursal as object ?? DBNull.Value };

            return await _db.Database.SqlQueryRaw<QRStockMinWithFilterDTO>(
                "EXEC SP_PRODUCTOS_BAJO_STOCK_REPOSICION @NombreSucursal", pSucursal)
                .ToListAsync();
        }
    }
}