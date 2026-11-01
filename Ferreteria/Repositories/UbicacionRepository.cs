using Ferreteria.Models;
using Ferreteria.Repositories;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Ferreteria.Repositories
{
    public class UbicacionRepository : IUbicacionRepository
    {
        private readonly FerreteriaContext _db;

        public UbicacionRepository(FerreteriaContext db)
        {
            _db = db;
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
            IEnumerable<Provincia>? provincia = _db.Provincias.AsNoTracking().ToList();

            return provincia;
        }
    }
}
