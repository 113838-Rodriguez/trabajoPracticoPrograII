using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync(bool traerInactivos);

        Task<Producto?> GetByIdAsync(int id);

        Task<Producto?> GetByCodigoAsync(string codigo);

        Task<bool> ExistsCodigoOrIdAsync(string codigo, int? productoId = null);

        Task<bool> ExistsCategoriaProductoAsync(int categoriaProductoId);

        Task<bool> ExistsTipoProductoAsync(int tipoProductoId);

        Task AddAsync(Producto producto);

        //UpdateAsync sirve para modificar o dar de baja un producto via el campo Activo
        Task UpdateAsync(Producto producto);

        Task<IEnumerable<CategoriaProducto>> GetCategoriasAsync();

        Task<IEnumerable<TipoProducto>> GetTiposAsync();
    }
}

