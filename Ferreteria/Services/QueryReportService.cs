using Ferreteria.DTOs;
using Ferreteria.Repositories;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class QueryReportService(QueryReportRepository repo) : IQueryReportService
    {
        public readonly QueryReportRepository _repo = repo;

        //Q1.Pablo
        public async Task<List<QRProductosSinVentasDTO>> GetProductosSinVentas(int dias)
        {
            return dias <= 0
                ? throw new ArgumentException("La cantidad de días debe ser mayor a 0")
                : await _repo.GetProductosSinVentas(dias);
        }

        //Q2.Maxi
        public async Task<List<QRStockbySucursalDTO>> GetStockbySucursal(string codigoProducto)
        {
            if (string.IsNullOrWhiteSpace(codigoProducto))
                throw new ArgumentException("El codigo de producto tiene q ser obligatorio");

            return await _repo.GetStockbySucursal(codigoProducto.Trim());
        }

        //Q3.Pablo
        public async Task<List<QREmpleadosySucursalesDTO>> GetEmpleadosySucursales(int? anio, int? sucursalID, int? empleadoId)
        {
            if (anio < 2000)
                throw new ArgumentException("El año debe ser posterior al 2000");
            if (anio > DateTime.Now.Year)
                throw new ArgumentException("El año debe ser menor o igual al ");
            if (sucursalID < 0)
                throw new ArgumentException("Valor de sucursal NO Valido");
            if (empleadoId < 0)
                throw new ArgumentException("Valor de Empleado NO Valido");

            return await _repo.GetEmpleadosySucursales(anio, sucursalID, empleadoId);
        }

        //Q4.Maxi
        public async Task<List<QRFacturacionTipoClienteDTO>> GetFacturacionTipoCliente(DateTime? fechaDesde, DateTime? fechaHasta)
        {
            if (fechaDesde == default || fechaHasta == default)
                throw new ArgumentException("Las fechas tienen que ser obligatorias");
            if (fechaDesde > fechaHasta)
                throw new ArgumentException("La fecha desde no puede ser menor a la fecha hasta");

            return await _repo.GetFacturacionTipoCliente(fechaDesde!.Value, fechaHasta!.Value);
        }

        //Q5.Pablo
        public async Task<List<QREntregasAtrasadasDTO>> GetEntregasAtrasadas(DateTime fechaReferencia)
        {
            if (fechaReferencia == default)
                throw new ArgumentException("La fecha es obligatorias");
            if (fechaReferencia < new DateTime(2020, 1, 1))
                throw new ArgumentException("La fecha debe ser superior a 01/01/2000");

            return await _repo.GetEntregasAtrasadas(fechaReferencia);
        }

        //Q6.Maxi
        public async Task<List<QRStockMinWithFilterDTO>> GetStockMinWithFilter(string? nombreSucursal)
        {
            var sucursal = string.IsNullOrWhiteSpace(nombreSucursal) ? null : nombreSucursal.Trim();

            return await _repo.GetStockMinWithFilter(sucursal);
        }
    }
}