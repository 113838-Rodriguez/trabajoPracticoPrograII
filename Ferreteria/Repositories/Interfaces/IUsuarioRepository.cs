using Ferreteria.Models;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();

        Task<Usuario?> GetByIdAsync(int id);

        Task<Usuario?> GetByUsernameAsync(string nombreUsuario);

        Task<bool> ExistsEmpleadoAsync(int empleadoId, int? usuarioId = null);

        Task<bool> ExistsRolAsync(int rolId);

        Task AddAsync(Usuario usuario);

        Task UpdateAsync(Usuario usuario);

        Task DeleteAsync(Usuario usuario);

        Task<bool> ExistsEmpleadoByIdAsync(int empleadoId);

        Task<bool> ExistsUsuarioSinEmpleadoAsync(int? usuarioId = null);
    }
}
