using Ferreteria.Models;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IUbicacionRepository
    {
        IEnumerable<Provincia> GetProvincias();

        Provincia? GetProvinciaById(int id);

        IEnumerable<Ciudade> GetCiudadesByProvincia(int provinciaId);

        IEnumerable<Barrio> GetBarriosByCiudad(int ciudadId);

        IEnumerable<Domicilio> GetDomiciliosByBarrio(int barrioId);
    }
}
