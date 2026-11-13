using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class UbicacionRepository(FerreteriaContext db) : IUbicacionRepository
    {
        private readonly FerreteriaContext _db = db;

        public async Task<IEnumerable<Provincia>>GetProvinciasAsync()
        {
            return await _db.Provincias
                .OrderBy(p => p.Descripcion)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ciudade>>GetCiudadesAsync(int provinciaId)
        {
            return await _db.Ciudades
                .Where(c => c.ProvinciaId == provinciaId)
                .OrderBy(c => c.Descripcion)
                .ToListAsync();
        }

        public async Task<IEnumerable<Barrio>>GetBarriosAsync(int ciudadId)
        {
            return await _db.Barrios
                .Where(b => b.CiudadId == ciudadId)
                .OrderBy(b => b.Descripcion).ToListAsync();
        }

        public async Task<Domicilio?> GetDomicilioByIdAsync(int domicilioId)
        {
            return await _db.Domicilios
                .Include(d => d.Barrio).ThenInclude(b => b.Ciudad).ThenInclude(c => c.Provincia)
                .FirstOrDefaultAsync(d => d.DomicilioId == domicilioId);
        }

        public async Task<bool> ExistsBarrioAsync(int barrioId)
        {
            return await _db.Barrios.AnyAsync(b => b.BarrioId == barrioId);
        }
    }
}
