using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class ClienteRepository(FerreteriaContext db) : IClienteRepository
    {
        private readonly FerreteriaContext _db = db;

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _db.Clientes
                .Where(c => c.Activo)
                .Include(c => c.TipoCliente).Include(c => c.Domicilio)
                .ThenInclude(d => d!.Barrio).ThenInclude(b => b.Ciudad).ThenInclude(c => c.Provincia)
                .ToListAsync();
        }
        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _db.Clientes
                .Where(c => c.Activo)
                .Include(c => c.TipoCliente).Include(c => c.Domicilio)
                .ThenInclude(d => d!.Barrio).ThenInclude(b => b.Ciudad).ThenInclude(c => c.Provincia)
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }
        public async Task AddAsync(Cliente cliente)
        {
            await _db.Clientes.AddAsync(cliente);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(Cliente cliente)
        {
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            _db.Clientes.Remove(cliente);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ExistsDniAsync(string dni, int? clienteId = null)
        {
            return await _db.Clientes
                .AnyAsync(c => c.Dni == dni && (!clienteId.HasValue || c.ClienteId != clienteId.Value));
        }

        public async Task<IEnumerable<Cliente>> GetInactivosAsync()
        {
            return await _db.Clientes
                .Where(c => !c.Activo)
                .Include(c => c.TipoCliente).Include(c => c.Domicilio)
                .ThenInclude(d => d!.Barrio).ThenInclude(b => b.Ciudad).ThenInclude(c => c.Provincia)
                .ToListAsync();
        }

        public async Task<Cliente?> GetByDniAsync(string dni)
        {
            return await _db.Clientes
                .Include(c => c.TipoCliente).Include(c => c.Domicilio)
                .FirstOrDefaultAsync(c => c.Dni == dni);
        }

        public async Task<bool> ExistsTipoClienteAsync(int tipoClienteId)
        {
            return await _db.TipoClientes
                .AnyAsync(t => t.TipoClienteId == tipoClienteId);
        }

        public async Task<bool> ExistsDomicilioAsync(int domicilioId)
        {
            return await _db.Domicilios
                .AnyAsync(d => d.DomicilioId == domicilioId);
        }

        //TipoCliente
        public async Task<IEnumerable<TipoCliente>> GetTipoClienteAllAsync()
        {
            return await _db.TipoClientes
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<TipoCliente?> GetTipoClienteByIdAsync(int id)
        {
            return await _db.TipoClientes
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TipoClienteId == id);
        }
    }
}
