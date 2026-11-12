using Ferreteria.DTOs;
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class ClienteService: IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClienteResponseDTO>> GetAllAsync()
        {
            var clientes = await _repository.GetAllClientesAsync();
            return clientes.Select(c => new ClienteResponseDTO
            {
                ClienteId = c.ClienteId,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                RazonSocial = c.RazonSocial,
                Cuil = c.Cuil,
                Dni = c.Dni,
                FechaAlta = c.FechaAlta,
                TipoClienteDescripcion = c.TipoCliente?.Descripcion ?? "Sin especificar",
                DomicilioId = c.DomicilioId,
                EstaActivo = c.Activo
            });
        }

        public async Task<ClienteResponseDTO?> GetByIdAsync(int id)
        {
            var c = await _repository.GetByIdAsync(id);
            if (c == null) return null;

            return new ClienteResponseDTO
            {
                ClienteId = c.ClienteId,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                RazonSocial = c.RazonSocial,
                Cuil = c.Cuil,
                Dni = c.Dni,
                FechaAlta = c.FechaAlta,
                TipoClienteDescripcion = c.TipoCliente?.Descripcion ?? "Sin especificar",
                DomicilioId = c.DomicilioId,
                EstaActivo = c.Activo
            };
        }

        public async Task<bool> CrearClienteAsync(CreateClienteDTO dto)
        {
            if (!string.IsNullOrEmpty(dto.Dni) && await _repository.ExistsDniAsync(dto.Dni))
                throw new InvalidOperationException("Ya existe un cliente registrado con ese DNI.");

            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                RazonSocial = dto.RazonSocial,
                Cuil = dto.Cuil,
                Dni = dto.Dni,
                FechaAlta = DateOnly.FromDateTime(DateTime.Now),
                TipoClienteId = dto.TipoClienteId,
                DomicilioId = dto.DomicilioId,
                Activo = dto.EstaActivo
            };

            await _repository.AddAsync(cliente);
            return true;
        }

        public async Task<bool> ModificarClienteAsync(int id, UpdateClienteDTO dto)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null) return false;

            cliente.Nombre = dto.Nombre;
            cliente.Apellido = dto.Apellido;
            cliente.RazonSocial = dto.RazonSocial;
            cliente.Cuil = dto.Cuil;
            cliente.Dni = dto.Dni;
            cliente.TipoClienteId = dto.TipoClienteId;
            cliente.DomicilioId = dto.DomicilioId;
            cliente.Activo = dto.EstaActivo;

            await _repository.UpdateAsync(cliente);
            return true;
        }

        public async Task<bool> EliminarClienteAsync(int id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null) return false;

            
            cliente.Activo = false; 
            await _repository.UpdateAsync(cliente);
            return true;
        }
    }
}
