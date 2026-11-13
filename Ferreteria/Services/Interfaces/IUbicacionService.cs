using Ferreteria.DTOs;

namespace Ferreteria.Services.Interfaces
{
    public interface IUbicacionService
    {
        Task<IEnumerable<ProvinciaDTO>> GetProvinciasAsync();
        Task<IEnumerable<CiudadDTO>> GetCiudadesAsync(int provinciaId);
        Task<IEnumerable<BarrioDTO>> GetBarriosAsync(int ciudadId);
        Task<DomicilioResponseDTO?> GetDomicilioByIdAsync(int domicilioId);
    }
}