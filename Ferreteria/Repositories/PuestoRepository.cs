
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class PuestoRepository : IPuestoRepository
    {
        private readonly FerreteriaContext _context;

        public PuestoRepository(FerreteriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Puesto>> GetAllAsync()
        {
            return await _context.Puestos
                .AsNoTracking()
                .OrderBy(p => p.Descripcion)
                .ToListAsync();
        }
    }
}
