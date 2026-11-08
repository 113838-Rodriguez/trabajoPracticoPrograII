
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository _sucursalRepository;

        public SucursalService(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }

        public async Task<IEnumerable<SucursalDTO>> GetAllAsync()
        {
            var sucursales = await _sucursalRepository.GetAllAsync();

            return sucursales.Select(s => new SucursalDTO
            {
                SucursalId = s.SucursalId,
                Descripcion = s.Descripcion
            }).ToList();
        }
    }
}
