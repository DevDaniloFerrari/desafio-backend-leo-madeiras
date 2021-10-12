using DesafioBackendLeoMadeiras.Domain.DTOs;
using DesafioBackendLeoMadeiras.Domain.Entities;

namespace DesafioBackendLeoMadeiras.Domain.Services
{
    public interface ITokenService
    {
        TokenDTO GerarToken(Usuario usuario);
    }
}
