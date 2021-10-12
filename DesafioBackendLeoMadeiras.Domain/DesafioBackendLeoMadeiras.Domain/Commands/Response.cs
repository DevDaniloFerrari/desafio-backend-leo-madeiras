namespace DesafioBackendLeoMadeiras.Domain.Commands
{
    public class Response
    {
        public Response(string mensagem, object dado, string[] erros = null)
        {
            Mensagem = mensagem;
            Dado = dado;
            Erros = erros;
        }

        public string Mensagem { get; set; }
        public object Dado { get; set; }
        public string[] Erros { get; set; }
    }
}
