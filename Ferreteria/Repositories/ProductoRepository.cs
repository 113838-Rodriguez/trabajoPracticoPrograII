using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly FerreteriaContext _context;

        public ProductoRepository(FerreteriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync(bool traerInactivos, string? codigoParcial = null)
        {
            var query = _context.Productos
                .Where(p => p.Activo == !traerInactivos)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(codigoParcial))
            {
                string texto = codigoParcial.Trim();

                query = query.Where(p => p.Codigo.Contains(texto));
            }

            return await query
                .Include(p => p.CategoriaProducto)
                .Include(p => p.TipoProducto)
                .OrderBy(p => p.Codigo)
                .ToListAsync();
        }

        //Busca producto por su ID INTERNO (productoId), si no lo encuentra devuelve null
        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.CategoriaProducto)
                .Include(p => p.TipoProducto)
                .FirstOrDefaultAsync(p => p.ProductoId == id);
        }

        //Busca producto por su CODIGO COMERCIAL (codigo), si no lo encuentra devuelve null
        public async Task<Producto?> GetByCodigoAsync(string codigo)
        {
            return await _context.Productos
                .Include(p => p.CategoriaProducto)
                .Include(p => p.TipoProducto)
                .FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        //Chequea si existe un producto con el mismo codigo, si se pasa un productoId, se excluye de la busqueda
        public async Task<bool> ExistsCodigoOrIdAsync(string codigo, int? productoId = null)
        {
            return await _context.Productos.AnyAsync(p =>
            p.Codigo == codigo &&
            (!productoId.HasValue || p.ProductoId != productoId.Value));
        }

        //Chequea si existe una categoria de producto con el mismo id
        public async Task<bool> ExistsCategoriaProductoAsync(int categoriaProductoId)
        {
            return await _context.CategoriaProductos.AnyAsync(c => c.CategoriaProductoId == categoriaProductoId);
        }

        //Chequea si existe un tipo de producto con el mismo id
        public async Task<bool> ExistsTipoProductoAsync(int tipoProductoId)
        {
            return await _context.TipoProductos.AnyAsync(t => t.TipoProductoId == tipoProductoId);
        }

        public async Task AddAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Producto producto)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoriaProducto>> GetCategoriasAsync()
        {
            return await _context.CategoriaProductos
                .AsNoTracking()
                .OrderBy(c => c.Descripcion)
                .ToListAsync();
        }

        public async Task<IEnumerable<TipoProducto>> GetTiposAsync()
        {
            return await _context.TipoProductos
                .AsNoTracking()
                .OrderBy(t => t.Descripcion)
                .ToListAsync();
        }
    }
}
