using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Ferreteria.Services
{

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public async Task CrearUsuarioAsync(CreateUsuarioDTO dto)
        {
            Usuario? usuarioExistente =
               await _usuarioRepository.GetByUsernameAsync(dto.NombreUsuario);

            if (usuarioExistente != null)
            {
                throw new InvalidOperationException("El nombre de usuario ya está registrado");

            }

            bool existeRol = await _usuarioRepository.ExistsRolAsync(dto.RolId);

            if (!existeRol)
            {
                throw new InvalidOperationException("El rol no existe");
            }

            if (dto.EmpleadoId.HasValue)
            {
                bool existeEmpleado =
                    await _usuarioRepository.ExistsEmpleadoByIdAsync(dto.EmpleadoId.Value);

                if (!existeEmpleado)
                {
                    throw new InvalidOperationException("El empleado no existe");
                }

                bool empleadoAsignado =
                    await _usuarioRepository.ExistsEmpleadoAsync(dto.EmpleadoId.Value);

                if (empleadoAsignado)
                {
                    throw new InvalidOperationException("El empleado ya tiene un usuario asignado");

                }
            }

            Usuario usuario = new Usuario
            {
                NombreUsuario = dto.NombreUsuario,
                RolId = dto.RolId,
                EmpleadoId = dto.EmpleadoId,
                Activo = true
            };


            // Generar hash de la contraseña
            PasswordHasher<Usuario> passwordHasher = new();

            usuario.PasswordHash = passwordHasher.HashPassword(usuario, dto.Password);

            await _usuarioRepository.AddAsync(usuario);


        }

        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            Usuario? usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                return false;
            }

            if (!usuario.Activo)
            {
                throw new InvalidOperationException("El usuario ya se encuentra desactivado");

            }

            usuario.Activo = false;

            await _usuarioRepository.UpdateAsync(usuario);

            return true;
        }

        public async Task<IEnumerable<UsuarioResponseDTO>> GetAllAsync()
        {
            IEnumerable<Usuario> usuarios = await _usuarioRepository.GetAllAsync();
          
            // recorre la coleccion
            return usuarios.Select(usuario => new UsuarioResponseDTO
            {
                UsuarioId = usuario.UsuarioId,
                NombreUsuario = usuario.NombreUsuario,
                Rol = usuario.Rol.Nombre,
                Activo = usuario.Activo,
                EmpleadoId = usuario.EmpleadoId
            });
        }

        public async Task<UsuarioResponseDTO?> GetByIdAsync(int id)
        {
            Usuario? usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                return null;
            }

            return new UsuarioResponseDTO
            {
                UsuarioId = usuario.UsuarioId,
                NombreUsuario = usuario.NombreUsuario,
                Rol = usuario.Rol.Nombre,
                Activo = usuario.Activo,
                EmpleadoId = usuario.EmpleadoId
            };
        }

        public  async Task<bool> ModificarUsuarioAsync(int id, UpdateUsuarioDTO dto)
        {
            Usuario? usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                return false;
            }

            Usuario? usuarioExistente = await _usuarioRepository.GetByUsernameAsync(dto.NombreUsuario);


            if (usuarioExistente != null && usuarioExistente.UsuarioId != id)
            {
                throw new InvalidOperationException("El nombre de usuario ya está registrado");

            }


            bool existeRol = await _usuarioRepository.ExistsRolAsync(dto.RolId);

            if (!existeRol)
            {
                throw new InvalidOperationException("El rol no existe");
            }

            if (dto.EmpleadoId.HasValue)
            {
                bool existeEmpleado =
                    await _usuarioRepository.ExistsEmpleadoByIdAsync(dto.EmpleadoId.Value);

                if (!existeEmpleado)
                {
                    throw new InvalidOperationException("El empleado no existe");
                }

                bool empleadoAsignado =
                    await _usuarioRepository.ExistsEmpleadoAsync(dto.EmpleadoId.Value, id);

                if (empleadoAsignado)
                {
                    throw new InvalidOperationException("El empleado ya tiene un usuario asignado");

                }
            }

            if (!dto.EmpleadoId.HasValue)
            {
                bool existeSinEmpleado =
                    await _usuarioRepository.ExistsUsuarioSinEmpleadoAsync(id);

                if (existeSinEmpleado)
                {
                    throw new InvalidOperationException(
                        "Ya existe otro usuario sin empleado asignado");
                }
            }

            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.RolId = dto.RolId;
            usuario.EmpleadoId = dto.EmpleadoId;
            usuario.Activo = dto.Activo;

            await _usuarioRepository.UpdateAsync(usuario);

            return true;

        }
    }
}
