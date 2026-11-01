using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class UbicacionService : IUbicacionService
    {
        private readonly IUbicacionRepository _ubicacionRepository;

        public UbicacionService(IUbicacionRepository ubicacionRepository)
        {
            _ubicacionRepository = ubicacionRepository;
        }
        public IEnumerable<Barrio> GetBarriosByCiudad(int ciudadId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ciudade> GetCiudadesByProvincia(int provinciaId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domicilio> GetDomiciliosByBarrio(int barrioId)
        {
            throw new NotImplementedException();
        }

        public Provincia? GetProvinciaById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Provincia> GetProvincias()
        {
            IEnumerable<Provincia>? provincia = _ubicacionRepository.GetProvincias();

            return provincia;
        }
    }
}
