namespace DesafioBackendLeoMadeiras.Domain.Entities
{
    public class Usuario : Entidade
    {
        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
