using System;
using System.Collections.Generic;
using System.Text;

using Ferreteria.Models;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllAsync(
            int? sucursalId,
            string? codigoParcial,
            bool soloBajoMinimo);

        Task<Stock?> GetByIdAsync(int id);
    }
}
