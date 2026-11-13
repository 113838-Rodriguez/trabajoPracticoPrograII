using Ferreteria.DTOs;
using Ferreteria.Models;
using Ferreteria.Repositories;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class ClienteService(IClienteRepository clienteRepo, IUbicacionRepository ubicacionRepo) : IClienteService
    {
        private readonly IClienteRepository _clienteRepo = clienteRepo;
        private readonly IUbicacionRepository _ubicacionRepo = ubicacionRepo;

        public async Task<IEnumerable<ClienteResponseDTO>> GetAllAsync()
        {
            var clientes = await _clienteRepo.GetAllClientesAsync();

            return clientes.Select(MapearCliente);
        }

        public async Task<ClienteResponseDTO?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID no es válido.");

            var cliente = await _clienteRepo.GetByIdAsync(id);

            return cliente == null
                ? null
                : MapearCliente(cliente);
        }

        public async Task<bool> CrearClienteAsync(ClienteDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Dni) && await _clienteRepo.ExistsDniAsync(dto.Dni.Trim()))
                throw new InvalidOperationException("Ya existe un cliente registrado con ese DNI.");


            if (dto.Domicilio != null)
            {
                bool barrioExiste = await _ubicacionRepo.ExistsBarrioAsync(dto.Domicilio.BarrioId);

                if (!barrioExiste)
                    throw new ArgumentException("El barrio seleccionado no existe.");
            }

            var cliente = new Cliente
            {
                Nombre = dto.Nombre.Trim(),
                Apellido = dto.Apellido?.Trim(),
                RazonSocial = dto.RazonSocial?.Trim(),
                Cuil = dto.Cuil?.Trim(),
                Dni = dto.Dni?.Trim(),

                FechaAlta = DateOnly.FromDateTime(DateTime.Now),
                TipoClienteId = dto.TipoClienteId,
                Activo = true,

                Domicilio = dto.Domicilio == null ? null : new Models.Domicilio
                {
                    Calle = dto.Domicilio.Calle.Trim(),
                    Numero = dto.Domicilio.Numero.Trim(),
                    Piso = dto.Domicilio.Piso?.Trim(),
                    Departamento = dto.Domicilio.Departamento?.Trim(),
                    BarrioId = dto.Domicilio.BarrioId
                }
            };

            await _clienteRepo.AddAsync(cliente);
            return true;
        }

        public async Task<bool> ModificarClienteAsync(int id, ClienteDTO dto)
        {
            var cliente = await _clienteRepo.GetByIdAsync(id);

            if (cliente == null)
                return false;

            if (!string.IsNullOrWhiteSpace(dto.Dni) && await _clienteRepo.ExistsDniAsync(dto.Dni.Trim(), id))
                throw new InvalidOperationException("Ya existe otro cliente registrado con ese DNI.");


            if (dto.Domicilio != null)
            {
                bool barrioExiste = await _ubicacionRepo.ExistsBarrioAsync(dto.Domicilio.BarrioId);

                if (!barrioExiste)
                    throw new ArgumentException("El barrio seleccionado no existe.");
            }

            // Actualizar datos del cliente
            cliente.Nombre = dto.Nombre.Trim();
            cliente.Apellido = dto.Apellido?.Trim();
            cliente.RazonSocial = dto.RazonSocial?.Trim();
            cliente.Cuil = dto.Cuil?.Trim();
            cliente.Dni = dto.Dni?.Trim();
            cliente.TipoClienteId = dto.TipoClienteId;

            // Actualizar domicilio
            if (dto.Domicilio == null)
            {
                cliente.Domicilio = null;
                cliente.DomicilioId = null;
            }
            else
            {
                // Si no tiene domicilio, crear uno
                if (cliente.Domicilio == null)
                    cliente.Domicilio = new Domicilio();

                // Si ya tiene domicilio, modificar el existente
                cliente.Domicilio.Calle = dto.Domicilio.Calle.Trim();
                cliente.Domicilio.Numero = dto.Domicilio.Numero.Trim();
                cliente.Domicilio.Piso = dto.Domicilio.Piso?.Trim();
                cliente.Domicilio.Departamento =
                    dto.Domicilio.Departamento?.Trim();
                cliente.Domicilio.BarrioId = dto.Domicilio.BarrioId;
            }

            await _clienteRepo.UpdateAsync(cliente);
            return true;
        }

        public async Task<bool> EliminarClienteAsync(int id)
        {
            var cliente = await _clienteRepo.GetByIdAsync(id);

            if (cliente == null)
                return false;

            cliente.Activo = false;

            await _clienteRepo.UpdateAsync(cliente);
            return true;
        }

        public async Task<IEnumerable<ClienteResponseDTO>> GetInactivosAsync()
        {
            var clientes = await _clienteRepo.GetInactivosAsync();

            return clientes.Select(MapearCliente);
        }

        public async Task<bool> ReactivarClienteAsync(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI es obligatorio.");

            dni = dni.Trim();
            var cliente = await _clienteRepo.GetByDniAsync(dni);

            if (cliente == null)
                throw new KeyNotFoundException("No existe un cliente registrado con ese DNI.");

            if (cliente.Activo)
                throw new InvalidOperationException("El cliente ya se encuentra activo.");

            cliente.Activo = true;

            await _clienteRepo.UpdateAsync(cliente);
            return true;
        }

        private static ClienteResponseDTO MapearCliente(Cliente c)
        {
            var domicilio = c.Domicilio;
            var barrio = domicilio?.Barrio;
            var ciudad = barrio?.Ciudad;
            var provincia = ciudad?.Provincia;

            return new ClienteResponseDTO
            {
                ClienteId = c.ClienteId,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                RazonSocial = c.RazonSocial,
                Cuil = c.Cuil,
                Dni = c.Dni,
                FechaAlta = c.FechaAlta,

                TipoClienteId = c.TipoClienteId,
                TipoClienteDescripcion = c.TipoCliente?.Descripcion ?? "Sin especificar",

                Domicilio = domicilio == null
                    ? null
                    : new DomicilioResponseDTO
                {
                    DomicilioId = domicilio.DomicilioId,
                    Calle = domicilio.Calle,
                    Numero = domicilio.Numero,
                    Piso = domicilio.Piso,
                    Departamento = domicilio.Departamento,

                    BarrioId = domicilio.BarrioId,
                    Barrio = barrio?.Descripcion ?? "Sin especificar",

                    CiudadId = barrio?.CiudadId ?? 0,
                    Ciudad = ciudad?.Descripcion ?? "Sin especificar",

                    ProvinciaId = ciudad?.ProvinciaId ?? 0,
                    Provincia = provincia?.Descripcion ?? "Sin especificar"
                }
            };
        }
        public async Task<IEnumerable<TipoClienteDTO>> GetTipoClienteAllAsync()
        {
            var tipos = await _clienteRepo.GetTipoClienteAllAsync();

            return tipos.Select(t => new TipoClienteDTO
            {
                TipoClienteId = t.TipoClienteId,
                Descripcion = t.Descripcion
            });
        }

        public async Task<TipoClienteDTO?> GetTipoClienteByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del tipo de cliente debe ser mayor a cero.");

            var tipo = await _clienteRepo.GetTipoClienteByIdAsync(id);

            return tipo == null
                ? null
                : new TipoClienteDTO
                {
                    TipoClienteId = tipo.TipoClienteId,
                    Descripcion = tipo.Descripcion
                };
        }
    }
}