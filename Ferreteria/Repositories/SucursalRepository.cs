
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly FerreteriaContext _context;

        public SucursalRepository(FerreteriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sucursale>> GetAllAsync()
        {
            return await _context.Sucursales
                .AsNoTracking()
                .OrderBy(s => s.Descripcion)
                .ToListAsync();
        }
    }
}
