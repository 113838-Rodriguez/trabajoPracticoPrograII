using Ferreteria.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoResponseDTO>> GetAllAsync(bool traerInactivos, string? codigoParcial = null);

        Task<ProductoResponseDTO?> GetByIdAsync(int id, bool incluirInactivos);

        Task<ProductoResponseDTO?> GetByCodigoAsync(string codigo, bool incluirInactivos);

        Task<ProductoResponseDTO> CreateAsync(ProductoRequestDTO dto);

        Task<ProductoResponseDTO?> UpdateAsync(string codigoActual, ProductoRequestDTO dto);

        Task<bool> DeleteAsync(string codigo);

        Task<bool> ReactivarProductoAsync(string codigo);

        Task<IEnumerable<OpcionProductoDTO>> GetCategoriasAsync();

        Task<IEnumerable<OpcionProductoDTO>> GetTiposAsync();
    }
}
