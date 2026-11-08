
using Ferreteria.Models;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IPuestoRepository
    {
        Task<IEnumerable<Puesto>> GetAllAsync();
    }
}