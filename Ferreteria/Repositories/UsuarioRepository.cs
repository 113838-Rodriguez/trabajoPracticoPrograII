using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly FerreteriaContext _context;

        public UsuarioRepository(FerreteriaContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public  async Task DeleteAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsEmpleadoAsync(int empleadoId, int? usuarioId = null)
        {
            return await _context.Usuarios.AnyAsync(x =>
                x.EmpleadoId == empleadoId &&
                (!usuarioId.HasValue || x.UsuarioId != usuarioId.Value));
        }

        public async Task<bool> ExistsEmpleadoByIdAsync(int empleadoId)
        {
            return await _context.Empleados.AnyAsync(e => e.EmpleadoId == empleadoId);

        }

        public async Task<bool> ExistsRolAsync(int rolId)
        {
            return await _context.Roles.AnyAsync(x => x.RolId == rolId);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(x => x.Rol)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
               .Include(x => x.Rol)
               .FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<Usuario?> GetByUsernameAsync(string nombreUsuario)
        {
            return await _context.Usuarios
               .FirstOrDefaultAsync(x => x.NombreUsuario == nombreUsuario);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> ExistsUsuarioSinEmpleadoAsync(int? usuarioId = null)
        {
            return await _context.Usuarios.AnyAsync(x => x.EmpleadoId == null && (!usuarioId.HasValue || x.UsuarioId != usuarioId.Value));

           
        }
    }
}
