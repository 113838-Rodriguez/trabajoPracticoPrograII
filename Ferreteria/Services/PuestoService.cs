
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class PuestoService : IPuestoService
    {
        private readonly IPuestoRepository _puestoRepository;

        public PuestoService(IPuestoRepository puestoRepository)
        {
            _puestoRepository = puestoRepository;
        }

        public async Task<IEnumerable<PuestoDTO>> GetAllAsync()
        {
            var puestos = await _puestoRepository.GetAllAsync();

            return puestos.Select(p => new PuestoDTO
            {
                PuestoId = p.PuestoId,
                Descripcion = p.Descripcion
            }).ToList();
        }
    }
}
