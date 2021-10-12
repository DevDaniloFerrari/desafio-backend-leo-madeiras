using Flunt.Notifications;
using System.Collections.Generic;

namespace DesafioBackendLeoMadeiras.Domain.Commands
{
    public class Response
    {
        public Response(string mensagem, object dado, IReadOnlyCollection<Notification> erros = null)
        {
            Mensagem = mensagem;
            Dado = dado;
            Notificacoes = erros;
        }

        public Response(string mensagem, IReadOnlyCollection<Notification> erros = null)
        {
            Mensagem = mensagem;
            Notificacoes = erros;
        }

        public string Mensagem { get; set; }
        public object Dado { get; set; }
        public IReadOnlyCollection<Notification> Notificacoes { get; set; }
    }
}
