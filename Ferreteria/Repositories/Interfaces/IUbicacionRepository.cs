
using Ferreteria.Models;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IUbicacionRepository
    {
        Task<IEnumerable<Provincia>> GetProvinciasAsync();
        Task<IEnumerable<Ciudade>> GetCiudadesAsync(int provinciaId);
        Task<IEnumerable<Barrio>> GetBarriosAsync(int ciudadId);
        Task<Domicilio?> GetDomicilioByIdAsync(int domicilioId);
        Task<bool> ExistsBarrioAsync(int barrioId);
    }
}
