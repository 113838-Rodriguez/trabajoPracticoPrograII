using Ferreteria.DTOs;
using Ferreteria.Models;

namespace Ferreteria.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginDTO dto);
    }
}
