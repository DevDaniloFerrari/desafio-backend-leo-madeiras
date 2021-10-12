using System;

namespace DesafioBackendLeoMadeiras.Domain.DTOs
{
    public class UsuarioDTO
    {
        public UsuarioDTO(string email, bool ehAutenticado)
        {
            Email = email;
            EhAutenticado = ehAutenticado;
        }

        public UsuarioDTO(string email, bool ehAutenticado, string token, DateTime tokenExpiraEm)
        {
            Email = email;
            EhAutenticado = ehAutenticado;
            Token = token;
            TokenExpiraEm = tokenExpiraEm;
        }

        public string Email { get; set; }
        public bool EhAutenticado { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiraEm { get; set; }
    }
}
