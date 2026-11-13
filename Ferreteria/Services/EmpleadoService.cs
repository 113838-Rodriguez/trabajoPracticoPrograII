
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{

    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<int> CrearEmpleadoAsync(CreateEmpleadoDTO dto)
        {
            
            bool existePuesto =
                await _empleadoRepository.ExistsPuestoAsync(dto.PuestoId);

            if (!existePuesto)
            {
                throw new InvalidOperationException(
                    "El puesto no existe");
            }

           
            bool existeSucursal =
                await _empleadoRepository.ExistsSucursalAsync(dto.SucursalId);

            if (!existeSucursal)
            {
                throw new InvalidOperationException(
                    "La sucursal no existe");
            }

           
            if (dto.DomicilioId.HasValue)
            {
                bool existeDomicilio =
                    await _empleadoRepository.ExistsDomicilioAsync(
                        dto.DomicilioId.Value);

                if (!existeDomicilio)
                {
                    throw new InvalidOperationException(
                        "El domicilio no existe");
                }
            }

            
            Empleado empleado = new Empleado
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.Dni,
                Cuil = dto.Cuil,
                FechaIngreso = dto.FechaIngreso,
                PuestoId = dto.PuestoId,
                DomicilioId = dto.DomicilioId,
                SucursalId = dto.SucursalId
            };

            
            await _empleadoRepository.AddAsync(empleado);

            
            return empleado.EmpleadoId;
        }

        public async Task<bool> EliminarEmpleadoAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException(
                    "El ID del empleado no es válido"
                );
            }

            return await _empleadoRepository.EliminarEmpleadoAsync(id);
        }

        public async Task<IEnumerable<EmpleadoResponseDTO>> GetAllAsync()
        {
            IEnumerable<Empleado> empleados =
                await _empleadoRepository.GetAllAsync();

            return empleados.Select(empleado => new EmpleadoResponseDTO
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Dni = empleado.Dni,
                Cuil = empleado.Cuil,
                FechaIngreso = empleado.FechaIngreso,
                PuestoId = empleado.PuestoId,
                DomicilioId = empleado.DomicilioId,
                SucursalId = empleado.SucursalId
            });
        }

        public async Task<EmpleadoResponseDTO?> GetByIdAsync(int id)
        {
            Empleado? empleado =
                await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
            {
                return null;
            }

            return new EmpleadoResponseDTO
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Dni = empleado.Dni,
                Cuil = empleado.Cuil,
                FechaIngreso = empleado.FechaIngreso,
                PuestoId = empleado.PuestoId,
                DomicilioId = empleado.DomicilioId,
                SucursalId = empleado.SucursalId
            };
        }
    }
}
