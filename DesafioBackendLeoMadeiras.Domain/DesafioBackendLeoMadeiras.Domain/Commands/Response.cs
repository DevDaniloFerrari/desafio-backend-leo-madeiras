using Flunt.Notifications;
using System.Collections.Generic;

namespace DesafioBackendLeoMadeiras.Domain.Commands
{
    public class Response
    {
        public Response(string mensagem, object dado, IReadOnlyCollection<Notification> notificacoes = null)
        {
            Mensagem = mensagem;
            Dado = dado;
            Notificacoes = notificacoes;
        }

        public Response(string mensagem, IReadOnlyCollection<Notification> notificacoes = null)
        {
            Mensagem = mensagem;
            Notificacoes = notificacoes;
        }

        public Response(IReadOnlyCollection<Notification> notificacoes = null)
        {
            Mensagem = "Erro";
            Notificacoes = notificacoes;
        }

        public string Mensagem { get; set; }
        public object Dado { get; set; }
        public IReadOnlyCollection<Notification> Notificacoes { get; set; }
    }
}
