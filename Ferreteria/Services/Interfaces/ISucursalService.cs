
using Ferreteria.Models;

namespace Ferreteria.Services.Interfaces
{
    public interface ISucursalService
    {
        Task<IEnumerable<SucursalDTO>> GetAllAsync();
    }
}
