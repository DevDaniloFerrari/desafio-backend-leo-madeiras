using DesafioBackendLeoMadeiras.Domain.Entities;
using DesafioBackendLeoMadeiras.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DesafioBackendLeoMadeiras.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario ObterUsuario(string email)
        {
            var usuarios = new List<Usuario>()
            {
                new Usuario("Usuário 1", "usuario1@email.com", "senha123"),
                new Usuario("Usuário 2", "usuario2@email.com", "senha456"),
                new Usuario("Usuário 3", "usuario3@email.com", "senha789")
            };

            return usuarios.FirstOrDefault(x => x.Email.Equals(email));
        }
    }
}
