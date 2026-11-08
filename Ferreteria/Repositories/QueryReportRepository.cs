using Ferreteria.DTOs;
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Ferreteria.Repositories
{
    public class QueryReportRepository(FerreteriaContext db) : IQueryReportRepository
    {
        public readonly FerreteriaContext _db = db;

        public Task<List<QREmpleadosySucursalesDTO>> GetEmpleadosySucursales()
        {
            throw new NotImplementedException();
        }

        public Task<List<QREntregasAtrasadasDTO>> GetEntregasAtrasadas()
        {
            throw new NotImplementedException();
        }

        public async Task<List<QRFacturacionTipoClienteDTO>> GetFacturacionTipoCliente(DateTime fechaDesde, DateTime fechaHasta)
        {
            var pDesde = new SqlParameter("@FechaDesde", SqlDbType.Date) { Value = fechaDesde.Date };
            var pHasta = new SqlParameter("@FechaHasta", SqlDbType.Date) { Value = fechaHasta.Date };

            return await _db.Database.SqlQueryRaw<QRFacturacionTipoClienteDTO>("EXEC sp_VentasPorTipoCliente @FechaDesde, @FechaHasta", pDesde, pHasta).ToListAsync();
        }

        public Task<List<QRProductosSinVentasDTO>> GetProductosSinVentas()
        {
            throw new NotImplementedException();
        }

        public async Task<List<QRStockbySucursalDTO>> GetStockbySucursal(string codigoProducto)

        {
            var pCodigo = new SqlParameter("@CodigoProducto", SqlDbType.VarChar, 30)
            {
                Value = codigoProducto
            };
            return await _db.Database.SqlQueryRaw<QRStockbySucursalDTO>("EXEC SP_ObtenerStockProductoPorSucursal @CodigoProducto", pCodigo).ToListAsync();
        }

        public async Task<List<QRStockMinWithFilterDTO>> GetStockMinWithFilter(string? nombreSucursal)
        {
            var pSucursal = new SqlParameter("@NombreSucursal", SqlDbType.VarChar, 100)
            {
                Value = (object?)nombreSucursal ?? DBNull.Value
            };
            return await _db.Database.SqlQueryRaw<QRStockMinWithFilterDTO>("EXEC SP_PRODUCTOS_BAJO_STOCK_REPOSICION @NombreSucursal", pSucursal).ToListAsync();
        }
    }
}