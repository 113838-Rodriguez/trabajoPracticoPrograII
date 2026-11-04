using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{

    public class AuthRepository : IAuthRepository
    {
        private readonly FerreteriaContext _context;

        public AuthRepository(FerreteriaContext context)
        {
            _context = context;
        }
        public async Task<Usuario?> GetByUsernameAsync(string nombreUsuario)
        {
            return await _context.Usuarios.Include(x => x.Rol).AsNoTracking().FirstOrDefaultAsync(x => x.NombreUsuario == nombreUsuario);
        }
    }
}
