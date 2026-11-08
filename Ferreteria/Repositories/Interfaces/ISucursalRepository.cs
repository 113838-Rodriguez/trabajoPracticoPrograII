
using Ferreteria.Models;

namespace Ferreteria.Repositories.Interfaces
{
    public interface ISucursalRepository
    {
        Task<IEnumerable<Sucursale>> GetAllAsync();
    }
}
