using Ferreteria.Models;

namespace Ferreteria.Services.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<Role>> GetAllAsync();
    }
}