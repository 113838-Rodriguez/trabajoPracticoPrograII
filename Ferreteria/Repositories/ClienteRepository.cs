using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class ClienteRepository:IClienteRepository
    {
        private readonly FerreteriaContext _context;
        public ClienteRepository(FerreteriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _context.Clientes
                // No se muestran los clientes dados de baja lógicamente.
                .Where(c => c.EstaActivo)
                .Include(c => c.TipoCliente)
                .Include(c => c.Domicilio)
                .ToListAsync();
        }
        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes
                // Un cliente inactivo no se considera disponible para la API.
                .Where(c => c.EstaActivo)
                .Include(c => c.TipoCliente)
                .Include(c => c.Domicilio)
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }
        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsDniAsync(string dni, int? clienteId = null)
        {
            return await _context.Clientes
                .AnyAsync(c => c.Dni == dni && (!clienteId.HasValue 
                || c.ClienteId != clienteId.Value));
        }

    }
}
