using Ferreteria.Models;
using Ferreteria.DTOs;
namespace Ferreteria.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponseDTO>> GetAllAsync();
        Task<ClienteResponseDTO?> GetByIdAsync(int id);
        Task<bool> CrearClienteAsync(CreateClienteDTO dto);
        Task<bool> ModificarClienteAsync(int id, UpdateClienteDTO dto);
        Task<bool> EliminarClienteAsync(int id);
    }
}
