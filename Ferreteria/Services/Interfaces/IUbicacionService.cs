using Ferreteria.Models;

namespace Ferreteria.Services.Interfaces
{
    public interface IUbicacionService
    {
        IEnumerable<Provincia> GetProvincias();

        Provincia? GetProvinciaById(int id);

        IEnumerable<Ciudade> GetCiudadesByProvincia(int provinciaId);

        IEnumerable<Barrio> GetBarriosByCiudad(int ciudadId);

        IEnumerable<Domicilio> GetDomiciliosByBarrio(int barrioId);
    }
}
