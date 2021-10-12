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
                new Usuario("Usuário 1", "usuario1@email.com", "mST8m5jbS8!eX26lPu3VC"),
                new Usuario("Usuário 2", "usuario2@email.com", "fm!@x_yOiN9xQE5bHigblF-"),
                new Usuario("Usuário 3", "usuario3@email.com", "@YfiGARAlxMVz8q")
            };

            return usuarios.FirstOrDefault(x => x.Email.Equals(email));
        }
    }
}
