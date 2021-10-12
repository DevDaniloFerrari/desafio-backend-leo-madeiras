using DesafioBackendLeoMadeiras.Domain.DTOs;
using DesafioBackendLeoMadeiras.Domain.Entities;
using DesafioBackendLeoMadeiras.Domain.Services;
using DesafioBackendLeoMadeiras.Domain.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioBackendLeoMadeiras.Infra.Services
{
    public class TokenService : ITokenService
    {
        public TokenDTO GerarToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfiguracaoToken.Chave);

            var claims = new List<Claim>()
            {
                new Claim("usuarioId", user.Id.ToString()),
                new Claim("usuarioEmail", user.Email),
            };

            var expireIn = DateTime.UtcNow.AddMinutes(5);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expireIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenWrite = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tokenWrite);

            return new TokenDTO(token, ObterTimezoneBrasil(expireIn));
        }

        private DateTime ObterTimezoneBrasil(DateTime dateUtc)
        {
            var brasiliaTime = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateUtc, brasiliaTime);
        }
    }
}
