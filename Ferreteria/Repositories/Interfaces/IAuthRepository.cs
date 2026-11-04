using Ferreteria.Models;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<Usuario?> GetByUsernameAsync(string nombreUsuario);
    }
}
