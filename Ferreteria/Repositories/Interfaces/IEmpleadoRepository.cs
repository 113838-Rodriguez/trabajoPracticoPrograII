using Ferreteria.Models;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetAllAsync();

        Task<Empleado?> GetByIdAsync(int id);

        Task<bool> ExistsPuestoAsync(int puestoId);

        Task<bool> ExistsSucursalAsync(int sucursalId);

        Task<bool> ExistsDomicilioAsync(int domicilioId);

        Task AddAsync(Empleado empleado);
    }
}