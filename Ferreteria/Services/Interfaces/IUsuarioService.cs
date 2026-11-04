namespace Ferreteria.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioResponseDTO>> GetAllAsync();

        Task<UsuarioResponseDTO?> GetByIdAsync(int id);

        Task CrearUsuarioAsync(CreateUsuarioDTO dto);

        Task<bool> ModificarUsuarioAsync(int id, UpdateUsuarioDTO dto);

        Task<bool> EliminarUsuarioAsync(int id);
    }
}
