using Ferreteria.DTOs;
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ferreteria.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<Usuario> _passwordHasher;

        public AuthService(
            IAuthRepository repository,
            IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
            _passwordHasher = new PasswordHasher<Usuario>();
        }

        public async Task<string?> LoginAsync(LoginDTO dto)
        {
            Usuario? usuario = await _repository
                .GetByUsernameAsync(dto.NombreUsuario);

            if (usuario == null || usuario.Activo != true)
                return null;

            var resultado = _passwordHasher.VerifyHashedPassword(
                usuario,
                usuario.PasswordHash,
                dto.Password
            );

            if (resultado == PasswordVerificationResult.Failed)
                return null;

            if (usuario.Rol == null)
                return null;

            return GenerarToken(usuario);
        }

        private string GenerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    usuario.UsuarioId.ToString()
                ),
                new Claim(
                    ClaimTypes.Name,
                    usuario.NombreUsuario
                ),
                new Claim(
                    ClaimTypes.Role,
                    usuario.Rol.Nombre
                )
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!
                )
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            int expirationMinutes = int.Parse(
                _configuration["Jwt:ExpirationMinutes"]!
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}