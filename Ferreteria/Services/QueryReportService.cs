using Ferreteria.DTOs;
using Ferreteria.Repositories;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class QueryReportService(QueryReportRepository repo) : IQueryReportService
    {
        public readonly QueryReportRepository _repo = repo;

        public Task<List<QRProductosSinVentasDTO>> GetProductosSinVentas()
        {
            throw new NotImplementedException();
        }

        public async Task<List<QRStockbySucursalDTO>> GetStockbySucursal(string codigoProducto)
        {
            if (string.IsNullOrWhiteSpace(codigoProducto))
                throw new ArgumentException("El codigo de producto tiene q ser obligatorio");

            return await _repo.GetStockbySucursal(codigoProducto.Trim());
        }

        public Task<List<QREmpleadosySucursalesDTO>> GetEmpleadosySucursales()
        {
            throw new NotImplementedException();
        }

        public async Task<List<QRFacturacionTipoClienteDTO>> GetFacturacionTipoCliente(DateTime? fechaDesde, DateTime? fechaHasta)
        {
            if (fechaDesde == default || fechaHasta == default)
                throw new ArgumentException("Las fechas tienen que ser obligatorias");
            if (fechaDesde > fechaHasta)
                throw new ArgumentException("La fecha desde no puede ser menor a la fecha hasta");

            return await _repo.GetFacturacionTipoCliente(fechaDesde!.Value, fechaHasta!.Value);
        }

        public Task<List<QREntregasAtrasadasDTO>> GetEntregasAtrasadas()
        {
            throw new NotImplementedException();
        }

        public async Task<List<QRStockMinWithFilterDTO>> GetStockMinWithFilter(string? nombreSucursal)
        {
            var sucursal = string.IsNullOrWhiteSpace(nombreSucursal) ? null : nombreSucursal.Trim();

            return await _repo.GetStockMinWithFilter(sucursal);
        }
    }
}