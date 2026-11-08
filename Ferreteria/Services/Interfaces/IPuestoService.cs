using Ferreteria.Models;

namespace Ferreteria.Services.Interfaces
{
    public interface IPuestoService
    {
        Task<IEnumerable<PuestoDTO>> GetAllAsync();
    }
}