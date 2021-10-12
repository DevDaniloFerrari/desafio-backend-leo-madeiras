using Flunt.Notifications;
using Flunt.Validations;
using MediatR;

namespace DesafioBackendLeoMadeiras.Domain.Commands
{
    public class ValidarSenhaCommand : Notifiable, IValidatable, IRequest<Response>
    {
        public string Senha { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                           .Requires()
                           .IsNotNullOrEmpty(Senha, "Senha", "A senha não pode ser vazia"));
        }
    }
}
