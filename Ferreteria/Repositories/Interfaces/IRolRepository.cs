using Ferreteria.Models;

namespace Ferreteria.Repositories.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
    }
}