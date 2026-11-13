using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class ChatService : IChatService
    {
        public Task<string> PreguntarAsync(string pregunta)
        {
            return Task.FromResult(
                $"Recibí tu pregunta: {pregunta}"
            );
        }
    }
}