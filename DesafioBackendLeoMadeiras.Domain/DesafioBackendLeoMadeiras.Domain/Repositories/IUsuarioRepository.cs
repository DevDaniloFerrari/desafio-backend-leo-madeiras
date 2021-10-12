namespace DesafioBackendLeoMadeiras.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario ObterUsuario(string email);
    }
}
