using System;

namespace DesafioBackendLeoMadeiras.Domain.DTOs
{
    public class TokenDTO
    {
        public TokenDTO(string token, DateTime expiraEm)
        {
            Token = token;
            ExpiraEm = expiraEm;
        }

        public string Token { get; set; }
        public DateTime ExpiraEm { get; set; }
    }
}
