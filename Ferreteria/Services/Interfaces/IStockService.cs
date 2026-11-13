using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria.DTOs;

namespace Ferreteria.Services.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<StockResponseDTO>> GetAllAsync(
            int? sucursalId,
            string? codigoParcial,
            bool soloBajoMinimo);

        Task<StockResponseDTO?> GetByIdAsync(int id);
    }
}
