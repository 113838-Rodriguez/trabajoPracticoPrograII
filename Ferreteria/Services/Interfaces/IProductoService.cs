using Ferreteria.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoResponseDTO>> GetAllAsync();

        Task<ProductoResponseDTO?> GetByIdAsync(int id, bool activoOnly);

        Task<ProductoResponseDTO?> GetByCodigoAsync(string codigo, bool activoOnly);

        Task<ProductoResponseDTO> CreateAsync(CreateProductoDTO dto);

        Task<ProductoResponseDTO?> UpdateAsync(int id, UpdateProductoDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}
