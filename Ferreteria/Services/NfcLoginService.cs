
using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace Ferreteria.Services
{
    public class NfcLoginService
    {
        private readonly ConcurrentDictionary<string, SolicitudNfc>
            _solicitudes = new();

        public string Iniciar()
        {
            LimpiarExpiradas();

            string id = Convert.ToHexString(
                RandomNumberGenerator.GetBytes(16));

            string clave = Convert.ToHexString(
                RandomNumberGenerator.GetBytes(32));

            _solicitudes[id] = new SolicitudNfc
            {
                ClaveConsulta = clave,
                Expira = DateTime.UtcNow.AddMinutes(2)
            };

            return id + ":" + clave;
        }

        public bool Autorizar(string id, string token)
        {
            if (!_solicitudes.TryGetValue(id, out var solicitud))
                return false;

            lock (solicitud)
            {
                if (DateTime.UtcNow > solicitud.Expira ||
                    solicitud.Token != null)
                    return false;

                solicitud.Token = token;
                return true;
            }
        }

        public string? ObtenerToken(string id, string clave)
        {
            if (!_solicitudes.TryGetValue(id, out var solicitud))
                return null;

            lock (solicitud)
            {
                if (DateTime.UtcNow > solicitud.Expira ||
                    solicitud.ClaveConsulta != clave ||
                    solicitud.Token == null)
                    return null;

                _solicitudes.TryRemove(id, out _);
                return solicitud.Token;
            }
        }

        private void LimpiarExpiradas()
        {
            foreach (var item in _solicitudes)
            {
                if (DateTime.UtcNow > item.Value.Expira)
                    _solicitudes.TryRemove(item.Key, out _);
            }
        }

        private class SolicitudNfc
        {
            public string ClaveConsulta { get; set; } = "";
            public DateTime Expira { get; set; }
            public string? Token { get; set; }
        }

        public bool AutorizarUnicaPendiente(string token)
        {
            LimpiarExpiradas();

            var pendientes = _solicitudes
                .Where(x => x.Value.Token == null &&
                            x.Value.Expira > DateTime.UtcNow)
                .ToList();

            // Solamente se permite una PC esperando
            if (pendientes.Count != 1)
                return false;

            return Autorizar(pendientes[0].Key, token);
        }
    }
}
