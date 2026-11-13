using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria.DTOs;
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _repository;

        public StockService(IStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StockResponseDTO>> GetAllAsync(
            int? sucursalId,
            string? codigoParcial,
            bool soloBajoMinimo)
        {
            if (sucursalId.HasValue && sucursalId.Value <= 0)
                throw new ArgumentException("La sucursal debe tener un ID válido.");

            var stocks = await _repository.GetAllAsync(
                sucursalId,
                codigoParcial?.Trim(),
                soloBajoMinimo
            );

            return stocks.Select(MapToResponse).ToList();
        }

        public async Task<StockResponseDTO?> GetByIdAsync(int id)
        {
            var stock = await _repository.GetByIdAsync(id);

            return stock == null ? null : MapToResponse(stock);
        }

        private static StockResponseDTO MapToResponse(Stock stock)
        {
            return new StockResponseDTO
            {
                StockId = stock.StockId,

                ProductoId = stock.ProductoId,
                CodigoProducto = stock.Producto.Codigo,
                DescripcionProducto = stock.Producto.Descripcion,
                ProductoActivo = stock.Producto.Activo,

                SucursalId = stock.SucursalId,
                Sucursal = stock.Sucursal.Descripcion,

                CantidadActual = stock.CantidadActual,
                StockMinimo = stock.StockMinimo,
                BajoMinimo = stock.CantidadActual < stock.StockMinimo
            };
        }
    }
}
