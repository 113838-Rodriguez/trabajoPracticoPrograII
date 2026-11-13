using Ferreteria.Models;
using Ferreteria.DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
namespace Ferreteria.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponseDTO>> GetAllAsync();
        Task<ClienteResponseDTO?> GetByIdAsync(int id);
        Task<bool> CrearClienteAsync(ClienteDTO dto);
        Task<bool> ModificarClienteAsync(int id, ClienteDTO dto);
        Task<bool> EliminarClienteAsync(int id);
        Task<IEnumerable<ClienteResponseDTO>> GetInactivosAsync();
        Task<bool> ReactivarClienteAsync(string dni);
        Task<IEnumerable<TipoClienteDTO>> GetTipoClienteAllAsync();
        Task<TipoClienteDTO?> GetTipoClienteByIdAsync(int id);
    }
}
