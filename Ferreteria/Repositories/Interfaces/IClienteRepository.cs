using Ferreteria.Models;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
        Task<bool> ExistsDniAsync(string dni, int? clienteId = null);
        Task<IEnumerable<Cliente>> GetInactivosAsync();
        Task<Cliente?> GetByDniAsync(string dni);
        Task<bool> ExistsTipoClienteAsync(int tipoClienteId);
        Task<bool> ExistsDomicilioAsync(int domicilioId);
        Task<IEnumerable<TipoCliente>> GetTipoClienteAllAsync();
        Task<TipoCliente?> GetTipoClienteByIdAsync(int id);
    }
}