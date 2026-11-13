
using Ferreteria.DTOs;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class UbicacionService(IUbicacionRepository repository) : IUbicacionService
    {
        private readonly IUbicacionRepository _repository = repository;

        public async Task<IEnumerable<ProvinciaDTO>>GetProvinciasAsync()
        {
            var provincias = await _repository.GetProvinciasAsync();

            return provincias.Select(p => new ProvinciaDTO
            {
                ProvinciaId = p.ProvinciaId,
                Descripcion = p.Descripcion
            });
        }

        public async Task<IEnumerable<CiudadDTO>> GetCiudadesAsync(int provinciaId)
        {
            if (provinciaId <= 0)
                throw new ArgumentException("La provincia seleccionada no es válida.");

            var ciudades = await _repository.GetCiudadesAsync(provinciaId);

            return ciudades.Select(c => new CiudadDTO
            {
                CiudadId = c.CiudadId,
                Descripcion = c.Descripcion,
                CodigoPostal = c.CodigoPostal,
                ProvinciaId = c.ProvinciaId
            });
        }

        public async Task<IEnumerable<BarrioDTO>>GetBarriosAsync(int ciudadId)
        {
            if (ciudadId <= 0)
                throw new ArgumentException("La ciudad seleccionada no es válida.");

            var barrios = await _repository.GetBarriosAsync(ciudadId);

            return barrios.Select(b => new BarrioDTO
            {
                BarrioId = b.BarrioId,
                Descripcion = b.Descripcion,
                CiudadId = b.CiudadId
            });
        }

        public async Task<DomicilioResponseDTO?>GetDomicilioByIdAsync(int domicilioId)
        {
            if (domicilioId <= 0)
                throw new ArgumentException("El domicilio seleccionado no es válido.");

            var d = await _repository.GetDomicilioByIdAsync( domicilioId);

            if (d == null)
                return null;

            return new DomicilioResponseDTO
            {
                DomicilioId = d.DomicilioId,
                Calle = d.Calle,
                Numero = d.Numero,
                Piso = d.Piso,
                Departamento = d.Departamento,

                BarrioId = d.BarrioId,
                Barrio = d.Barrio.Descripcion,

                CiudadId = d.Barrio.CiudadId,
                Ciudad = d.Barrio.Ciudad.Descripcion,

                ProvinciaId = d.Barrio.Ciudad.ProvinciaId,
                Provincia = d.Barrio.Ciudad.Provincia.Descripcion
            };
        }
    }
}