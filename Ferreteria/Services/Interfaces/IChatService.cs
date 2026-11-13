namespace Ferreteria.Services.Interfaces
{
    public interface IChatService
    {
        Task<string> PreguntarAsync(string pregunta);
    }
}