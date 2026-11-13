using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly FerreteriaContext _context;

        public StockRepository(FerreteriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllAsync(
            int? sucursalId,
            string? codigoParcial,
            bool soloBajoMinimo)
        {
            IQueryable<Stock> query = _context.Stocks
                .AsNoTracking();

            if (sucursalId.HasValue)
            {
                query = query.Where(s =>
                    s.SucursalId == sucursalId.Value);
            }

            if (!string.IsNullOrWhiteSpace(codigoParcial))
            {
                query = query.Where(s =>
                    s.Producto.Codigo.Contains(codigoParcial));
            }

            if (soloBajoMinimo)
            {
                query = query.Where(s =>
                    s.CantidadActual < s.StockMinimo);
            }

            return await query
                .Include(s => s.Producto)
                .Include(s => s.Sucursal)
                .OrderBy(s => s.Sucursal.Descripcion)
                .ThenBy(s => s.Producto.Codigo)
                .ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks
                .AsNoTracking()
                .Include(s => s.Producto)
                .Include(s => s.Sucursal)
                .FirstOrDefaultAsync(s => s.StockId == id);
        }
    }
}
