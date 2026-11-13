using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;
using Ferreteria.DTOs;

namespace Ferreteria.Services
{
    public class QueryReportService(IQueryReportRepository repo) : IQueryReportService
    {
        public readonly IQueryReportRepository _repo = repo;

        public async Task<List<QRProductosSinVentasDTO>> GetProductosSinVentas(int dias)
        {
            return dias <= 0
                ? throw new ArgumentException("La cantidad de días debe ser mayor a 0")
                : await _repo.GetProductosSinVentas(dias);
        }

        public async Task<List<QRStockbySucursalDTO>> GetStockbySucursal(string codigoProducto)
        {
            return string.IsNullOrWhiteSpace(codigoProducto)
                ? throw new ArgumentException("El codigo de producto tiene q ser obligatorio")
                : await _repo.GetStockbySucursal(codigoProducto.Trim());
        }

        public async Task<List<SucursalComboDTO>> GetSucursales()
        {
            return await _repo.GetSucursales();
        }
        public async Task<List<EmpleadoComboDTO>> GetEmpleadosPorSucursal(int sucursalID)
        {
            return sucursalID <= 0
                ? throw new ArgumentException("Sucursal inválida.")
                : await _repo.GetEmpleadosPorSucursal(sucursalID);
        }
        public async Task<List<QREmpleadosySucursalesDTO>> GetEmpleadosySucursales(int? anio, int? sucursalID, int? empleadoId)
        {
            if (anio < 2000)
                throw new ArgumentException("El año debe ser posterior al 2000");
            if (anio > DateTime.Now.Year)
                throw new ArgumentException("El año debe ser igual o menor al año actual ");
            if (sucursalID < 0)
                throw new ArgumentException("Valor de sucursal NO Valido");
            if (empleadoId < 0)
                throw new ArgumentException("Valor de Empleado NO Valido");

            return await _repo.GetEmpleadosySucursales(anio, sucursalID, empleadoId);
        }

        public async Task<List<QRFacturacionTipoClienteDTO>> GetFacturacionTipoCliente(DateTime? fechaDesde, DateTime? fechaHasta)
        {
            if (fechaDesde == default || fechaHasta == default)
                throw new ArgumentException("Las fechas tienen que ser obligatorias");
            if (fechaDesde > fechaHasta)
                throw new ArgumentException("La fecha desde no puede ser menor a la fecha hasta");
            
            return await _repo.GetFacturacionTipoCliente(fechaDesde!.Value, fechaHasta!.Value);
        }

        public async Task<List<QREntregasAtrasadasDTO>> GetEntregasAtrasadas(DateOnly fechaReferencia)
        {
            if (fechaReferencia == default)
                fechaReferencia = DateOnly.FromDateTime(DateTime.Now);
            if (fechaReferencia < new DateOnly(2020, 1, 1))
                throw new ArgumentException("La fecha debe ser superior a 01/01/2000");
            
            return await _repo.GetEntregasAtrasadas(fechaReferencia);
        }

        public async Task<List<QRStockMinWithFilterDTO>> GetStockMinWithFilter(string? nombreSucursal)
        {
            var sucursal = string.IsNullOrWhiteSpace(nombreSucursal)
                ? null
                : nombreSucursal.Trim();

            return await _repo.GetStockMinWithFilter(sucursal);
        }
    }
}