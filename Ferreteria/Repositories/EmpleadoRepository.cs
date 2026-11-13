using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly FerreteriaContext _context;

        public EmpleadoRepository(FerreteriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Empleados
                .AsNoTracking()
                .Where(e => e.Activo)
                .ToListAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _context.Empleados
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EmpleadoId == id);
        }

        public async Task<bool> ExistsPuestoAsync(int puestoId)
        {
            return await _context.Puestos
                .AnyAsync(x => x.PuestoId == puestoId);
        }

        public async Task<bool> ExistsSucursalAsync(int sucursalId)
        {
            return await _context.Sucursales
                .AnyAsync(x => x.SucursalId == sucursalId);
        }

        public async Task<bool> ExistsDomicilioAsync(int domicilioId)
        {
            return await _context.Domicilios
                .AnyAsync(x => x.DomicilioId == domicilioId);
        }

        public async Task AddAsync(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);

            await _context.SaveChangesAsync();
        }


        public async Task<bool> EliminarEmpleadoAsync(int id)
        {
            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(e => e.EmpleadoId == id);

            if (empleado == null)
            {
                return false;
            }

            if (!empleado.Activo)
            {
                throw new InvalidOperationException(
                    "El empleado ya se encuentra dado de baja."
                );
            }

            empleado.Activo = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}