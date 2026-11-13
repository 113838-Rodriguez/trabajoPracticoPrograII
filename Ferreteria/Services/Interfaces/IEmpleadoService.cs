
using Ferreteria.Models;

namespace Ferreteria.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoResponseDTO>> GetAllAsync();

        Task<EmpleadoResponseDTO?> GetByIdAsync(int id);

        Task<int> CrearEmpleadoAsync(CreateEmpleadoDTO dto);

        Task<bool> EliminarEmpleadoAsync(int id);
    }
}